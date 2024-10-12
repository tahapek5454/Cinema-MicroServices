using Cinema.Services.CategoryAPI.Application.Services.Abstract;
using MassTransit;
using SharedLibrary.Events.MovieChangeEvents;
using SharedLibrary.Models.SharedModels.Movies;
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
                    await Insert(context.Message, sendEndpoint);
                    break;
                case SharedLibrary.Enums.CRUDStatusEnum.Update:
                    await Update(context.Message, sendEndpoint);
                    break;
                case SharedLibrary.Enums.CRUDStatusEnum.Delete:
                    break;
                default:
                    break;
            }

            
        }

        private async Task Insert(MovieChangeFillCategoryEvent message, ISendEndpoint sendEndpoint)
        {
            var movieIds = message.MovieIds;
            var categoryIds = message.CategoryIds;

            if (movieIds.Count != categoryIds.Count)
            {
                await sendEndpoint.Send(new MovieChangeNotReceivedFromCategoryEvent(message.CorrelationId)
                {
                    CategoryIds = categoryIds,
                    CrudStatus = message.CrudStatus,
                    MovieIds = movieIds,
                });
                return;
            }

            foreach (var (movieId, categoryId) in movieIds.Zip(categoryIds, (movieId, categoryId) => (movieId, categoryId)))
            {
                var category = await _categoryService.GetByIdAsync(categoryId);

                if (category is null)
                {
                    await sendEndpoint.Send(new MovieChangeNotReceivedFromCategoryEvent(message.CorrelationId)
                    {
                        CategoryIds = categoryIds,
                        CrudStatus = message.CrudStatus,
                        MovieIds = movieIds,
                    });
                    return; 
                }

                var targetMovie = await _sharedMovieRepository.GetByIdAsync(movieId);

                if (targetMovie is null)
                {
                    await sendEndpoint.Send(new MovieChangeNotReceivedFromCategoryEvent(message.CorrelationId)
                    {
                        CategoryIds = categoryIds,
                        CrudStatus = message.CrudStatus,
                        MovieIds = movieIds,
                    });
                    return;
                }

                targetMovie.Category = new()
                {
                    Id = category.Id,
                    Name = category.Name,
                };

                await _sharedMovieRepository.UpdateAsync(movieId, targetMovie);
            }

            await sendEndpoint.Send(new MovieChangeReceivedFromCategoryEvent(message.CorrelationId)
            {
                CategoryIds = message.CategoryIds,
                MovieIds = message.MovieIds,
                CrudStatus = message.CrudStatus
            });
        }

        private async Task Update(MovieChangeFillCategoryEvent message, ISendEndpoint sendEndpoint)
        {

            var movieIds = message.MovieIds;
            var categoryIds = message.CategoryIds;
            var updateReults = message.UpdateResults;

            if (movieIds.Count != categoryIds.Count)
            {
                await sendEndpoint.Send(new MovieChangeNotReceivedFromCategoryEvent(message.CorrelationId)
                {
                    CategoryIds = categoryIds,
                    CrudStatus = message.CrudStatus,
                    MovieIds = movieIds,
                    UpdateResults = updateReults,
                    OldMovieValues = message.OldMovieValues
                });
                return;
            }

            if(!updateReults?.Any() ?? true)
            {
                await sendEndpoint.Send(new MovieChangeNotReceivedFromCategoryEvent(message.CorrelationId)
                {
                    CategoryIds = categoryIds,
                    CrudStatus = message.CrudStatus,
                    MovieIds = movieIds,
                    UpdateResults = updateReults,
                    OldMovieValues = message.OldMovieValues
                });
                return;
            }

            List<MovieSharedVM> updatedMovie = [];

            foreach (var (movieId, categoryId) in movieIds.Zip(categoryIds, (movieId, categoryId) => (movieId, categoryId)))
            {
                var category = await _categoryService.GetByIdAsync(categoryId);

                if (category is null)
                {
                    await sendEndpoint.Send(new MovieChangeNotReceivedFromCategoryEvent(message.CorrelationId)
                    {
                        CategoryIds = categoryIds,
                        CrudStatus = message.CrudStatus,
                        MovieIds = movieIds,
                        UpdateResults = updateReults,
                        OldMovieValues = message.OldMovieValues
                    });
                    return;
                }

                var targetMovie = await _sharedMovieRepository.GetByIdAsync(movieId);

                if (targetMovie is null)
                {
                    await sendEndpoint.Send(new MovieChangeNotReceivedFromCategoryEvent(message.CorrelationId)
                    {
                        CategoryIds = categoryIds,
                        CrudStatus = message.CrudStatus,
                        MovieIds = movieIds,
                        UpdateResults = updateReults,
                        OldMovieValues = message.OldMovieValues
                    });
                    return;
                }

                targetMovie.Category = new()
                {
                    Id = category.Id,
                    Name = category.Name,
                };

                updatedMovie.Add(targetMovie);
            }

            foreach (var item in updatedMovie)
            {
                await _sharedMovieRepository.UpdateAsync(item.Id, item);
            }

            await sendEndpoint.Send(new MovieChangeReceivedFromCategoryEvent(message.CorrelationId)
            {
                CategoryIds = message.CategoryIds,
                MovieIds = message.MovieIds,
                CrudStatus = message.CrudStatus,
                UpdateResults = message.UpdateResults,
            });

        }
    }
}
