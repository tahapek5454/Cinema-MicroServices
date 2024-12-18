﻿using Cinema.Services.FileAPI.Application.Services.Abstract;
using Cinema.Services.FileAPI.Infrastructure.Services.Concrete;
using Cinema.Services.FileAPI.Storages.Abstract;
using MassTransit;
using SharedLibrary.Events.MovieChangeEvents;
using SharedLibrary.Events.MovieChangeEvents.AddMovieEvents;
using SharedLibrary.Repositories.SharedModelRepositories.Abstract;
using SharedLibrary.Settings;

namespace Cinema.Services.FileAPI.Infrastructure.Consumer
{
    public class MovieChangeFillMovieImageEventConsumer(IMovieImageService _movieImageService,
        ISharedMovieRepository _sharedMovieRepository,
        ISendEndpointProvider _sendEndpointProvider,
        IStorageService _storageService,
        FileUnitOfWork _fileUnitOfWork) : IConsumer<MovieChangeFillMovieImageEvent>
    {
        public async Task Consume(ConsumeContext<MovieChangeFillMovieImageEvent> context)
        {

            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint
                (new Uri($"queue:{RabbitMQSettings.MovieChangeStateMachineQueue}"));


            switch (context.Message.CrudStatus)
            {
                case SharedLibrary.Enums.CRUDStatusEnum.Insert:
                    await Insert(context.Message, sendEndpoint);
                    break;
                case SharedLibrary.Enums.CRUDStatusEnum.Update:
                    await Update(context.Message, sendEndpoint);
                    break;
                case SharedLibrary.Enums.CRUDStatusEnum.Delete:
                    await Delete(context.Message, sendEndpoint);
                    break;
                default:
                    break;
            }

            

        }

        private async Task Insert(MovieChangeFillMovieImageEvent message, ISendEndpoint sendEndpoint)
        {
            foreach (var movieId in message.MovieIds)
            {
                var images = _movieImageService.Table.Where(x => x.RelationId.Equals(movieId)).ToList();

                if (!images.Any())
                    continue;

                var movie = await _sharedMovieRepository.GetByIdAsync(movieId);

                if (movie is null)
                    continue;

                movie.MovieImages = images.Select(x => new SharedLibrary.Models.SharedModels.Images.MovieImageSharedVM()
                {
                    Id = x.Id,
                    FileName = x.FileName,
                    MovieId = movieId,
                    Path = x.Path,
                    Storage = x.Storage
                }).ToList();

                await _sharedMovieRepository.UpdateAsync(movie.Id, movie);
            }

            await sendEndpoint.Send(new MovieChangeReceivedFromFileEvent(message.CorrelationId)
            {
                MovieIds = message.MovieIds,
            });
        }

        private async Task Update(MovieChangeFillMovieImageEvent message, ISendEndpoint sendEndpoint)
        {
            foreach (var movieId in message.MovieIds)
            {
                var images = _movieImageService.Table.Where(x => x.RelationId.Equals(movieId)).ToList();

                if (!images.Any())
                    continue;

                var movie = await _sharedMovieRepository.GetByIdAsync(movieId);

                if (movie is null)
                    continue;

                movie.MovieImages = images.Select(x => new SharedLibrary.Models.SharedModels.Images.MovieImageSharedVM()
                {
                    Id = x.Id,
                    FileName = x.FileName,
                    MovieId = movieId,
                    Path = x.Path,
                    Storage = x.Storage
                }).ToList();

                await _sharedMovieRepository.UpdateAsync(movie.Id, movie);
            }

            await sendEndpoint.Send(new MovieChangeReceivedFromFileEvent(message.CorrelationId)
            {
                MovieIds = message.MovieIds,
            });
        }


        private async Task Delete(MovieChangeFillMovieImageEvent message, ISendEndpoint sendEndpoint)
        {
            foreach (var movieId in message.MovieIds)
            {
                var images = _movieImageService.Table.Where(x => x.RelationId.Equals(movieId)).ToList();

                foreach (var image in images)
                {
                    await _storageService.DeleteAsync("images", image.FileName);
                }

                if (images.Any())
                {
                    _movieImageService.Table.RemoveRange(images);
                    await _fileUnitOfWork.SaveChangesAsync();
                }

            }

            await sendEndpoint.Send(new MovieChangeReceivedFromFileEvent(message.CorrelationId)
            {
                MovieIds = message.MovieIds,
            });
        }
    }
}
