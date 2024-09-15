using Cinema.Services.MovieAPI.Application.Dtos.Movies;
using SharedLibrary.Behaviors;

namespace Cinema.Services.MovieAPI.Application.Queries.Movies.GetMoviesWithPagination
{
    public class GetMoviesWithPaginationResponse : CommonResponse<List<MovieDto>>
    {
        public int TotalCount { get; set; }
    }
}
