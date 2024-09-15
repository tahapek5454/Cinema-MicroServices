using MediatR;

namespace Cinema.Services.MovieAPI.Application.Queries.Movies.GetMoviesWithPagination
{
    public class GetMoviesWithPaginationRequest : IRequest<GetMoviesWithPaginationResponse>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
    }
}
