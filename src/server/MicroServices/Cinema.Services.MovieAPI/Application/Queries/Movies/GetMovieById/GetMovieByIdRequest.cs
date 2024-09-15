using MediatR;

namespace Cinema.Services.MovieAPI.Application.Queries.Movies.GetMovieById
{
    public class GetMovieByIdRequest : IRequest<GetMovieByIdResponse>
    {
        public int Id { get; set; }
    }
}
