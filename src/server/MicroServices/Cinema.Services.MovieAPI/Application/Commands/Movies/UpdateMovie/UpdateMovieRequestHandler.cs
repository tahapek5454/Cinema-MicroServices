using Cinema.Services.MovieAPI.Application.Services.Abstract;
using Cinema.Services.MovieAPI.Infrastructure.Services.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Dtos;

namespace Cinema.Services.MovieAPI.Application.Commands.Movies.UpdateMovie
{
    public class UpdateMovieRequestHandler(IMovieService _movieService, MovieUnitOfWork _movieUnitOfWork) : IRequestHandler<UpdateMovieRequest, UpdateMovieResponse>
    {
        public async Task<UpdateMovieResponse> Handle(UpdateMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = await _movieService.Table.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (movie is null) throw new Exception("Güncellenecek Film Bulunamadı.");


            var count = _movieService.UpdateAdvance(movie, request);

            if (count > 0)
            {
                await _movieUnitOfWork.SaveChangesAsync();
            }


            return new UpdateMovieResponse()
            {
                Result = ResponseDto<BlankDto>.Sucess(200)
            };

        }
    }
}
