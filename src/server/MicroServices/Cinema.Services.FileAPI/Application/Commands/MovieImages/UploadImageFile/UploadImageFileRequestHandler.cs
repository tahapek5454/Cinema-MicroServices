using Cinema.Services.FileAPI.Application.Services.Abstract;
using Cinema.Services.FileAPI.Domain.Entities;
using Cinema.Services.FileAPI.Infrastructure.Services.Concrete;
using Cinema.Services.FileAPI.Storages.Abstract;
using MassTransit;
using MediatR;
using SharedLibrary.Events.MovieImageEvents;
using SharedLibrary.Settings;

namespace Cinema.Services.FileAPI.Application.Commands.MovieImages.UploadImageFile
{
    public class UploadImageFileRequestHandler(IStorageService _storageService, IMovieImageService _movieImageService, ISendEndpointProvider _sendEndpointProvider, FileUnitOfWork _fileUnitOfWork) : IRequestHandler<UploadImageFileRequest, UploadImageFileResponse>
    {
        public async Task<UploadImageFileResponse> Handle(UploadImageFileRequest request, CancellationToken cancellationToken)
        {   
            if (request.FormFileCollection == null)
                throw new Exception("Couldn't Access Files");

            var result = await _storageService.UploadAsync("images", request.FormFileCollection);

            List<MovieImage> images = new List<MovieImage>();

            result.ForEach(item =>
            {
                MovieImage image = new MovieImage()
                {
                    FileName = item.fileName,
                    Path = item.pathOrContainerName,
                    Storage = _storageService.StorageName,
                    RelationId = request.RelationId
                };

                images.Add(image);
            });

            if (!images.Any())
            {
                foreach (var item in result)
                    await _storageService.DeleteAsync("images", item.fileName);

                throw new Exception("Couldn't Save Files");
            }

            await _movieImageService.Table.AddRangeAsync(images);
            await _fileUnitOfWork.SaveChangesAsync();

            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQSettings.FileStateMachineQueue}"));

            images.ForEach(async image =>
            {
                MovieImageUploadStartedEvent movieImageUploadStartedEvent = new MovieImageUploadStartedEvent()
                {
                    FileId = image.Id,
                    FileName = image.FileName,
                    Path = image.Path,
                    RelationId = image.RelationId,
                    Storage = image.Storage,

                };

                await sendEndpoint.Send(movieImageUploadStartedEvent);
            });

            return new();
        }
    }
}
