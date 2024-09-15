using Cinema.Services.MovieAPI.Application.Services.Abstract;
using Cinema.Services.MovieAPI.Infrastructure.Services.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Dtos;

namespace Cinema.Services.MovieAPI.Application.Commands.Movies.RemoveMovie
{
    public class RemoveMovieRequestHandler(IMovieService _movieService, MovieUnitOfWork _movieUnitOfWork) : IRequestHandler<RemoveMovieRequest, RemoveMovieResponse>
    {
        public async Task<RemoveMovieResponse> Handle(RemoveMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = await _movieService.Table.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (movie is null)
                throw new Exception("Movie is not found");

            _movieService.Table.Remove(movie);

            await _movieUnitOfWork.SaveChangesAsync();


            return new()
            {
                Result = ResponseDto<BlankDto>.Sucess(200)
            };
        }
    }
}
