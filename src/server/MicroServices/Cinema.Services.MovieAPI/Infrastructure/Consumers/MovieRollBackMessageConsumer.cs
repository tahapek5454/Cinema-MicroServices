using Cinema.Services.MovieAPI.Application.Services.Abstract;
using Cinema.Services.MovieAPI.Infrastructure.Services.Concrete;
using MassTransit;
using SharedLibrary.Messages;
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
    }
}
