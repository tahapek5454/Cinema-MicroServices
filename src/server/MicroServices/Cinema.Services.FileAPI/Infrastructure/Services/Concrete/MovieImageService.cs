using Cinema.Services.FileAPI.Application.Repositories;
using Cinema.Services.FileAPI.Application.Services.Abstract;
using Cinema.Services.FileAPI.Domain.Entities;
using SharedLibrary.Services;

namespace Cinema.Services.FileAPI.Infrastructure.Services.Concrete
{
    public class MovieImageService : BaseEntityService<MovieImage>, IMovieImageService
    {
        private readonly IMovieImageRepository _repository;
        public MovieImageService(IHttpClientFactory _httpClientFactory, IMovieImageRepository repository) : base(_httpClientFactory, repository)
        {
            _repository = repository;
        }
    }
}
