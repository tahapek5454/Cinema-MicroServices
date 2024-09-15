using Cinema.Services.MovieAPI.Application.Mapper;
using Cinema.Services.MovieAPI.Application.Services.Abstract;
using Cinema.Services.MovieAPI.Domain.Entities;
using Cinema.Services.MovieAPI.Infrastructure.Services.Concrete;
using MediatR;
using SharedLibrary.Models.Dtos;

namespace Cinema.Services.MovieAPI.Application.Commands.Movies.AddMovie
{
    public class AddMovieRequestHandler(IMovieService _movieService, MovieUnitOfWork _movieUnitOfWork) : IRequestHandler<AddMovieRequest, AddMovieResponse>
    {
        public async Task<AddMovieResponse> Handle(AddMovieRequest request, CancellationToken cancellationToken)
        {
            var newMovie = ObjectMapper.Mapper.Map<Movie>(request);

            await _movieService.Table.AddAsync(newMovie);

            await _movieUnitOfWork.SaveChangesAsync();

            return new()
            {
                Result = ResponseDto<int>.Sucess(newMovie.Id, 201)
            };
        }
    }
}
