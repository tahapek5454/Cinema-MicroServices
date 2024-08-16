using Cinema.Services.MovieAPI.Application.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Dtos;

namespace Cinema.Services.MovieAPI.Application.Commands.UpdateMovie
{
    public class UpdateMovieRequestHandler(IMovieService _movieService) : IRequestHandler<UpdateMovieRequest, UpdateMovieResponse>
    {
        public async Task<UpdateMovieResponse> Handle(UpdateMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = await _movieService.Table.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (movie is null) throw new Exception("Güncellenecek Film Bulunamadı.");


            var count = _movieService.AdvancedUpdate(movie, request);

            if (count > 0)
            {
                await _movieService.SaveChangesAsync();
            }


            return new UpdateMovieResponse()
            {
                Result = ResponseDto<BlankDto>.Sucess(200)
            };

        }
    }
}
