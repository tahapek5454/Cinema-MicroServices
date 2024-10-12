using Cinema.Services.MovieAPI.Application.Services.Abstract;
using Cinema.Services.MovieAPI.Infrastructure.Services.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Repositories.SharedModelRepositories.Abstract;

namespace Cinema.Services.MovieAPI.Application.Commands.Movies.RemoveMovie
{
    public class RemoveMovieRequestHandler(IMovieService _movieService, MovieUnitOfWork _movieUnitOfWork ,ISharedMovieRepository _sharedMovieRepository) : IRequestHandler<RemoveMovieRequest, RemoveMovieResponse>
    {
        public async Task<RemoveMovieResponse> Handle(RemoveMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = await _movieService.Table.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (movie is null)
                throw new Exception("Movie is not found");

            _movieService.Table.Remove(movie);

            await _movieUnitOfWork.SaveChangesAsync();


            await _sharedMovieRepository.DeleteAsync(request.Id);

            // Silme işlemini MovieChange sürecine şimdilik dahil etmedim.
            // Eğer Session Reservation süreçlerinde read modelinde Momive nesnesi bulunacaksa
            // Olası Movie Update ve Delete lerinde FillFromSession süreci eklenmeli ve güncellenmeli
            // Şimdilik buraya girmiyorum.

            return new()
            {
                Result = ResponseDto<BlankDto>.Sucess(200)
            };
        }
    }
}
