using MediatR;

namespace Cinema.Services.MovieAPI.Application.Commands.Movies.RemoveMovie
{
    public class RemoveMovieRequest : IRequest<RemoveMovieResponse>
    {
        public int Id { get; set; }
    }
}
