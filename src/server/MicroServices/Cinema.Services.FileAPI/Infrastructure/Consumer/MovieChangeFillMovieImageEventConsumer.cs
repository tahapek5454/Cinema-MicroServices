using Cinema.Services.FileAPI.Application.Services.Abstract;
using MassTransit;
using SharedLibrary.Events.MovieChangeEvents;
using SharedLibrary.Events.MovieChangeEvents.AddMovieEvents;
using SharedLibrary.Repositories.SharedModelRepositories.Abstract;
using SharedLibrary.Settings;

namespace Cinema.Services.FileAPI.Infrastructure.Consumer
{
    public class MovieChangeFillMovieImageEventConsumer(IMovieImageService _movieImageService,  ISharedMovieRepository _sharedMovieRepository, ISendEndpointProvider _sendEndpointProvider) : IConsumer<MovieChangeFillMovieImageEvent>
    {
        public async Task Consume(ConsumeContext<MovieChangeFillMovieImageEvent> context)
        {

            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint
                (new Uri($"queue:{RabbitMQSettings.MovieChangeStateMachineQueue}"));


            switch (context.Message.CrudStatus)
            {
                case SharedLibrary.Enums.CRUDStatusEnum.Insert:
                    await Insert(context, sendEndpoint);
                    break;
                case SharedLibrary.Enums.CRUDStatusEnum.Update:
                    break;
                case SharedLibrary.Enums.CRUDStatusEnum.Delete:
                    break;
                default:
                    break;
            }

            

        }

        private async Task Insert(ConsumeContext<MovieChangeFillMovieImageEvent> context, ISendEndpoint sendEndpoint)
        {
            foreach (var movieId in context.Message.MovieIds)
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
            }

            await sendEndpoint.Send(new MovieChangeReceivedFromFileEvent(context.Message.CorrelationId)
            {
                MovieIds = context.Message.MovieIds,
            });
        }
    }
}
