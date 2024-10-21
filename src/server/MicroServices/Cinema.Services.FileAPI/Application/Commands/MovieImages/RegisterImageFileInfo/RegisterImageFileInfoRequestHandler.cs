using Cinema.Services.FileAPI.Application.Services.Abstract;
using Cinema.Services.FileAPI.Domain.Entities;
using Cinema.Services.FileAPI.Storages.Abstract;
using MassTransit;
using MediatR;
using SharedLibrary.Events.MovieImageEvents;
using SharedLibrary.Repositories.SharedModelRepositories.Abstract;
using SharedLibrary.Settings;

namespace Cinema.Services.FileAPI.Application.Commands.MovieImages.RegisterImageFileInfo
{
    public class RegisterImageFileInfoRequestHandler(IMovieImageService _movieImageService, IStorageService _storageService, ISharedMovieRepository _sharedMovieRepository, ISendEndpointProvider _sendEndpointProvider) : IRequestHandler<RegisterImageFileInfoRequest, RegisterImageFileInfoResponse>
    {
        public async Task<RegisterImageFileInfoResponse> Handle(RegisterImageFileInfoRequest request, CancellationToken cancellationToken)
        {
            if (request.RelationDatas is null)
                return new();

            List<MovieImage> addedEntites = new List<MovieImage>();
            List<MovieImageUploadStartedEvent> @events = new List<MovieImageUploadStartedEvent>();
            foreach (var item in request.RelationDatas)
            {
                var hasFile = _storageService.HasFile("images", item.FileFullName);

                if(!hasFile)
                    continue;

                addedEntites.Add(new()
                {
                    FileName = item.FileFullName,
                    Path = "images",
                    RelationId = item.RelationId,
                    Storage = _storageService.StorageName,
                });
            }

            if (!addedEntites.Any())
                return new();

            await _movieImageService.AddRangeAsync(addedEntites);
            await _movieImageService.SaveChangesAsync();

            foreach (var item in addedEntites)
            {
                @events.Add(new()
                {
                    FileId = item.Id,
                    FileName = item.FileName,
                    Path = item.Path,
                    RelationId = item.RelationId,
                    Storage = item.Storage,

                });


                var movieShared = await _sharedMovieRepository.GetByIdAsync(item.RelationId);

                if (movieShared != null)
                {
                    movieShared.MovieImages ??= new List<SharedLibrary.Models.SharedModels.Images.MovieImageSharedVM>();

                    movieShared.MovieImages.Add(new SharedLibrary.Models.SharedModels.Images.MovieImageSharedVM()
                    {
                        FileName = item.FileName,
                        Id = item.Id,
                        MovieId = item.RelationId,
                        Path = item.Path,
                        Storage = item.Storage
                    });

                    await _sharedMovieRepository.UpdateAsync(movieShared.Id, movieShared);
                }
            }


            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQSettings.FileStateMachineQueue}"));

            addedEntites.ForEach(async image =>
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
