using Cinema.Services.MovieAPI.Application.Repositories;
using Cinema.Services.MovieAPI.Application.Services.Abstract;
using Cinema.Services.MovieAPI.Domain.Entities;
using SharedLibrary.Services;

namespace Cinema.Services.MovieAPI.Infrastructure.Services.Concrete;

public class MovieImageService : BaseEntityService<MovieImage>, IMovieImageService
{
    private readonly IMovieImageRepository _movieImageRepository;
    public MovieImageService(IHttpClientFactory _httpClientFactory, IMovieImageRepository repository) : base(_httpClientFactory, repository)
    {
        _movieImageRepository = repository;
    }
}

