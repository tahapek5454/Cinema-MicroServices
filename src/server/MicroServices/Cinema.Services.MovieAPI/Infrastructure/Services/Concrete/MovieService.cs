using Cinema.Services.MovieAPI.Application.Repositories;
using Cinema.Services.MovieAPI.Application.Services.Abstract;
using Cinema.Services.MovieAPI.Domain.Entities;
using SharedLibrary.Services;

namespace Cinema.Services.MovieAPI.Infrastructure.Services.Concrete
{
    public class MovieService : BaseEntityService<Movie>, IMovieService
    {
        private readonly IMovieRepository _repository;
        public MovieService(IHttpClientFactory _httpClientFactory, IMovieRepository repository) : base(_httpClientFactory, repository)
        {
            _repository = repository;
        }
    }
}
