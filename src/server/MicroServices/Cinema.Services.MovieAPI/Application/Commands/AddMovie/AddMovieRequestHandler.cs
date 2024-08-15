using Cinema.Services.MovieAPI.Application.Mapper;
using Cinema.Services.MovieAPI.Application.Services.Abstract;
using Cinema.Services.MovieAPI.Domain.Entities;
using MediatR;
using SharedLibrary.Models.Dtos;

namespace Cinema.Services.MovieAPI.Application.Commands.AddMovie
{
    public class AddMovieRequestHandler(IMovieService _movieService) : IRequestHandler<AddMovieRequest, AddMovieResponse>
    {
        public async Task<AddMovieResponse> Handle(AddMovieRequest request, CancellationToken cancellationToken)
        {
            var newMovie = ObjectMapper.Mapper.Map<Movie>(request);

            await _movieService.Table.AddAsync(newMovie);

            await _movieService.SaveChangesAsync();

            return new()
            {
                Result = ResponseDto<int>.Sucess(newMovie.Id, 201)
            };
        }
    }
}
