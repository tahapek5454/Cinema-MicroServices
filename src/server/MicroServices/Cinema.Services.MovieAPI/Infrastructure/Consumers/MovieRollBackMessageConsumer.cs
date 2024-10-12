using Cinema.Services.MovieAPI.Application.Mapper;
using Cinema.Services.MovieAPI.Application.Services.Abstract;
using Cinema.Services.MovieAPI.Domain.Entities;
using Cinema.Services.MovieAPI.Infrastructure.Services.Concrete;
using MassTransit;
using SharedLibrary.Messages;
using SharedLibrary.Models.SharedModels.Movies;
using SharedLibrary.Repositories.SharedModelRepositories.Abstract;

namespace Cinema.Services.MovieAPI.Infrastructure.Consumers
{
    public class MovieRollBackMessageConsumer(IMovieService _movieService, ISharedMovieRepository _sharedMovieRepository, MovieUnitOfWork _movieUnitOfWork) : IConsumer<MovieRollBackMessage>
    {
        public async Task Consume(ConsumeContext<MovieRollBackMessage> context)
        {
            switch (context.Message.CrudStatus)
            {
                case SharedLibrary.Enums.CRUDStatusEnum.Insert:
                    await InsertCompensable(context.Message);
                    break;
                case SharedLibrary.Enums.CRUDStatusEnum.Update:
                    await UpdateCompensable(context.Message);
                    break;
                case SharedLibrary.Enums.CRUDStatusEnum.Delete:
                    break;
                default:
                    break;
            }
        }


        private async Task InsertCompensable(MovieRollBackMessage message)
        {
            var ids = message.MovieIds;

            _movieService.DeleteRange(ids);
            await _movieUnitOfWork.SaveChangesAsync();

            await _sharedMovieRepository.DeleteRangeByIdsAsync(ids);
        }

        private async Task UpdateCompensable(MovieRollBackMessage message)
        {
            var ids = message.MovieIds;

            if(message.UpdateResults is null || !message.UpdateResults.Any())           
                return;

            List<Movie> updatedMovies = [];
            foreach(var movieId in ids)
            {
                var updateResults = message.UpdateResults.Where(x  => x.ModelPk.Equals(movieId)).ToList(); 
                var updateMovie = await _movieService.GetByIdAsync(movieId);

                if (updateMovie == null || !updateResults.Any())
                    continue;

                _movieService.UpdatePartialRollback(updateMovie, updateResults);

                updatedMovies.Add(updateMovie);
            }
            
            if (updatedMovies.Any())
            {
                _movieService.Table.UpdateRange(updatedMovies);
                await _movieUnitOfWork.SaveChangesAsync();

                foreach (var item in updatedMovies)
                {
                    var sharedModel = ObjectMapper.Mapper.Map<MovieSharedVM>(item);
                    var oldSharedModel = message.OldMovieValues?.FirstOrDefault(x => x.Id.Equals(item.Id));

                    sharedModel.Category = oldSharedModel?.Category;
                    await _sharedMovieRepository.UpdateAsync(sharedModel.Id, sharedModel);
                }
            }
        }
    }
}
