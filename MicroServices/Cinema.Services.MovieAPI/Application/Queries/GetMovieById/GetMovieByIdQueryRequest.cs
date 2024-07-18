using MediatR;

namespace Cinema.Services.MovieAPI.Application.Queries.GetMovieById
{
    public class GetMovieByIdQueryRequest: IRequest<GetMovieByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
