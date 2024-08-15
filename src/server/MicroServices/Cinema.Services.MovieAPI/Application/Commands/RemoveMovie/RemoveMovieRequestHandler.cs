using Cinema.Services.MovieAPI.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Dtos;

namespace Cinema.Services.MovieAPI.Application.Commands.RemoveMovie
{
    public class RemoveMovieRequestHandler(IMovieService _movieService) : IRequestHandler<RemoveMovieRequest, RemoveMovieResponse>
    {
        public async Task<RemoveMovieResponse> Handle(RemoveMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = await _movieService.Table.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (movie is null)
                throw new Exception("Movie is not found");

            _movieService.Table.Remove(movie);

            await _movieService.SaveChangesAsync();


            return new()
            {
                Result = ResponseDto<BlankDto>.Sucess(200)
            };
        }
    }
}
