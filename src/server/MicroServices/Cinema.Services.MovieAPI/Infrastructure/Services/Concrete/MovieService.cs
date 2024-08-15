using Cinema.Services.MovieAPI.Application.Repositories;
using Cinema.Services.MovieAPI.Application.Services.Abstract;
using Cinema.Services.MovieAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.MovieAPI.Infrastructure.Services.Concrete
{
    public class MovieService : BaseService, IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IHttpClientFactory _httpClientFactory, IMovieRepository movieRepository):base(_httpClientFactory) 
        {
            _movieRepository = movieRepository;
        }

        public DbSet<Movie> Table => _movieRepository.Table;

        public int SaveChanges()
        {
            return _movieRepository.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _movieRepository.SaveChangesAsync();
        }
    }
}
