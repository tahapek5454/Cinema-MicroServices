using MassTransit;
using SharedLibrary.Events.CategoryChangeEvent;
using SharedLibrary.Events.MovieImageEvents;
using SharedLibrary.Repositories.SharedModelRepositories.Abstract;
using SharedLibrary.Settings;

namespace Cinema.Services.MovieAPI.Infrastructure.Consumers
{
    public class CategoryChangeFillMovieEventConsumer(ISharedMovieRepository sharedMovieRepository, ISendEndpointProvider _sendEndpointProvider) : IConsumer<CategoryChangeFillMovieEvent>
    {
        public async Task Consume(ConsumeContext<CategoryChangeFillMovieEvent> context)
        {
            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint
                (new Uri($"queue:{RabbitMQSettings.CategoryChangeStateMachineQueue}"));

            var movies = sharedMovieRepository.Get().Where(x => x.CategoryId == context.Message.CategoryId).ToList();
            foreach(var movie in movies)
            {
                movie.Category = context.Message.CategorySharedVM;
                await sharedMovieRepository.UpdateAsync(movie.Id, movie);
            }

            await sendEndpoint.Send(new CategoryChangeReceivedFromMovieEvent(context.Message.CorrelationId){ CategoryId = context.Message.CategoryId });
        }
    }
}
