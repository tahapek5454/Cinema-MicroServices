using SharedLibrary.Models.SharedModels.Movies;

namespace Cinema.Services.AiAssistant.Services.Abstract
{
    public interface IAppService
    {
        Task<MovieSharedVM?> GetHighestRatedMovie();
        Task<MovieSharedVM?> GetMoviesWithPagination(string movieName);
        Task<List<MovieSharedVM>> GetMoviesWithPagination(int page=1, int size = 10);
    }
}
