using MediatR;

namespace Cinema.Services.MovieAPI.Application.Queries.GetMovieById
{
    public class GetMovieByIdRequest: IRequest<GetMovieByIdResponse>
    {
        public int Id { get; set; }
    }
}
