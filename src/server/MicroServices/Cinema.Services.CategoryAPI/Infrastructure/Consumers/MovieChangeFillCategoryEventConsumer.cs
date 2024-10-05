using Cinema.Services.CategoryAPI.Application.Services.Abstract;
using MassTransit;
using SharedLibrary.Events.MovieChangeEvents;
using SharedLibrary.Repositories.SharedModelRepositories.Abstract;
using SharedLibrary.Settings;

namespace Cinema.Services.CategoryAPI.Infrastructure.Consumers
{
    public class MovieChangeFillCategoryEventConsumer(ICategoryService _categoryService, ISharedMovieRepository _sharedMovieRepository, ISendEndpointProvider _sendEndpointProvider) : IConsumer<MovieChangeFillCategoryEvent>
    {

        public async Task Consume(ConsumeContext<MovieChangeFillCategoryEvent> context)
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

        private async Task Insert(ConsumeContext<MovieChangeFillCategoryEvent> context, ISendEndpoint sendEndpoint)
        {
            var movieIds = context.Message.MovieIds;
            var categoryIds = context.Message.CategoryIds;

            if (movieIds.Count != categoryIds.Count)
            {
                await sendEndpoint.Send(new MovieChangeNotReceivedFromCategoryEvent(context.Message.CorrelationId)
                {
                    CategoryIds = categoryIds,
                    CrudStatus = context.Message.CrudStatus,
                    MovieIds = movieIds,
                });
                return;
            }

            foreach (var (movieId, categoryId) in movieIds.Zip(categoryIds, (movieId, categoryId) => (movieId, categoryId)))
            {
                var category = await _categoryService.GetByIdAsync(categoryId);

                if (category is null)
                {
                    await sendEndpoint.Send(new MovieChangeNotReceivedFromCategoryEvent(context.Message.CorrelationId)
                    {
                        CategoryIds = categoryIds,
                        CrudStatus = context.Message.CrudStatus,
                        MovieIds = movieIds,
                    });
                    break; 
                }

                var targetMovie = await _sharedMovieRepository.GetByIdAsync(movieId);

                if (targetMovie is null)
                {
                    await sendEndpoint.Send(new MovieChangeNotReceivedFromCategoryEvent(context.Message.CorrelationId)
                    {
                        CategoryIds = categoryIds,
                        CrudStatus = context.Message.CrudStatus,
                        MovieIds = movieIds,
                    });
                    break;
                }

                targetMovie.Category = new()
                {
                    Id = category.Id,
                    Name = category.Name,
                };

                await _sharedMovieRepository.UpdateAsync(movieId, targetMovie);
            }

            await sendEndpoint.Send(new MovieChangeReceivedFromCategoryEvent(context.Message.CorrelationId)
            {
                CategoryIds = context.Message.CategoryIds,
                MovieIds = context.Message.MovieIds,
                CrudStatus = context.Message.CrudStatus
            });
        }
    }
}
