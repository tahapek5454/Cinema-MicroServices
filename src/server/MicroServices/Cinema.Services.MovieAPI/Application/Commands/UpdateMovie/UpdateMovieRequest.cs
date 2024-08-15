using MediatR;

namespace Cinema.Services.MovieAPI.Application.Commands.UpdateMovie
{
    public class UpdateMovieRequest: IRequest<UpdateMovieResponse>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Name_EN { get; set; }
        public string? Description { get; set; }
        public string? Description_EN { get; set; }
        public double? Point { get; set; }
        public double? Time { get; set; }
        public int? CategoryId { get; set; }
    }
}
