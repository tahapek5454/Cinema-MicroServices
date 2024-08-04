using Cinema.Services.MovieAPI.Models.Entities;
using Cinema.Services.MovieAPI.Services.Abstract;
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


            var entityType = typeof(Movie);
            var requestType = typeof(UpdateMovieRequest);

            var entityProperties = entityType.GetProperties();
            var requestProperties = requestType.GetProperties();

            var pk = entityType.GetProperty("Id");

            var updateFlag = false;

            // request and entity properties have to same
            foreach (var requestProperty in requestProperties)
            {
                var entityProperty = entityProperties.FirstOrDefault(p => p.Name == requestProperty.Name);
                var updatedValue = requestProperty.GetValue(request);

                if (entityProperty != null && updatedValue != null && requestProperty != pk)
                {
                    entityProperty.SetValue(movie, updatedValue);
                    updateFlag = true;
                }
            }

            if (updateFlag)
            {
                _movieService.Table.Update(movie);
                await _movieService.SaveChangesAsync();
            }


            return new UpdateMovieResponse()
            {
                Result = ResponseDto<BlankDto>.Sucess(200)
            };

        }
    }
}
