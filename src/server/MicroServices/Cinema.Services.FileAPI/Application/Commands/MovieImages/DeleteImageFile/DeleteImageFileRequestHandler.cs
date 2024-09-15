using Cinema.Services.FileAPI.Application.Services.Abstract;
using Cinema.Services.FileAPI.Infrastructure.Services.Concrete;
using Cinema.Services.FileAPI.Storages.Abstract;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Events.MovieImageEvents;
using SharedLibrary.Settings;

namespace Cinema.Services.FileAPI.Application.Commands.MovieImages.DeleteImageFile
{
    public class DeleteImageFileRequestHandler(IStorageService _storageService, IMovieImageService _movieImageService, ISendEndpointProvider _sendEndpointProvider, FileUnitOfWork _fileUnitOfWork) : IRequestHandler<DeleteImageFileRequest, DeleteImageFileResponse>
    {
        public async Task<DeleteImageFileResponse> Handle(DeleteImageFileRequest request, CancellationToken cancellationToken)
        {
            await _storageService.DeleteAsync("images", request.FileName);

            var file = await _movieImageService.Table.FirstOrDefaultAsync(x => x.FileName.Equals(request.FileName));

            MovieImageDeleteStartedEvent movieImageDeleteStartedEvent = new MovieImageDeleteStartedEvent()
            {
                FileId = file.Id,
                FileName = file.FileName,
                Path = file.Path,
                RelationId = file.RelationId,
                Storage = file.Storage,

            };

            if (file is null)
                throw new Exception("File Not Found");

            _movieImageService.Table.Remove(file);
            await _fileUnitOfWork.SaveChangesAsync();

            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQSettings.FileStateMachineQueue}"));

            await sendEndpoint.Send(movieImageDeleteStartedEvent);

            return new();
        }
    }
}
