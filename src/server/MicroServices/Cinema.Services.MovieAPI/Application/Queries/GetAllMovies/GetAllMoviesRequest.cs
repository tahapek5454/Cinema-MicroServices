using MediatR;

namespace Cinema.Services.MovieAPI.Application.Queries.GetAllMovies
{
    public class GetAllMoviesRequest: IRequest<GetAllMoviesResponse>
    {
    }
}
