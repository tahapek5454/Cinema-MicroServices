using Cinema.Services.MovieAPI.Models.Dtos.Movies;
using SharedLibrary.Behaviors;

namespace Cinema.Services.MovieAPI.Application.Queries.GetMoviesWithPagination
{
    public class GetMoviesWithPaginationResponse: CommonResponse<List<MovieDto>>
    {
        public int TotalCount { get; set; }
    }
}
