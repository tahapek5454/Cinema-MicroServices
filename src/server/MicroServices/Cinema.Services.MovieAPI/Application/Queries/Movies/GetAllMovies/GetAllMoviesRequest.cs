using MediatR;

namespace Cinema.Services.MovieAPI.Application.Queries.Movies.GetAllMovies
{
    public class GetAllMoviesRequest : IRequest<GetAllMoviesResponse>
    {
    }
}
