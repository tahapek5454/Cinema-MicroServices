using Cinema.Services.AiAssistant.Services.Abstract;
using SharedLibrary.Models.SharedModels.Movies;
using SharedLibrary.Repositories.SharedModelRepositories.Abstract;

namespace Cinema.Services.AiAssistant.Services.Concrete
{
    public class AppService(ISharedMovieRepository _sharedMovieRepository) : IAppService
    {
        public async Task<MovieSharedVM?> GetHighestRatedMovie()
        {
            var movie =  _sharedMovieRepository.Query().OrderByDescending(x => x.Point).FirstOrDefault();

            return await Task.FromResult(movie);
        }

        public async Task<MovieSharedVM?> GetMoviesByName(string movieName)
        {
            var movie = _sharedMovieRepository.Query().FirstOrDefault(x => x.Name.Equals(movieName, StringComparison.CurrentCultureIgnoreCase));

            return await Task.FromResult(movie);
        }

        public async Task<List<MovieSharedVM>> GetMoviesWithPagination(int page=1, int size=10)
        {
            var movies = _sharedMovieRepository.Query().OrderByDescending(x => x.CreatedDate)
                .Skip((page-1 <= 0 ? 0 : page-1) * size)
                .Take(size)
                .ToList();

            return await Task.FromResult(movies); 
        }
    }
}
