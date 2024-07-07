using Cinema.Services.MovieAPI.Data.Contexts;
using Cinema.Services.MovieAPI.Models.Entities;
using Cinema.Services.MovieAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.MovieAPI.Services.Concrete
{
    public class MovieService : BaseService, IMovieService
    {
        private readonly AppDbContext _appDbContext;
        public MovieService(IHttpClientFactory _httpClientFactory, AppDbContext appDbContext) : base(_httpClientFactory)
        {
            _appDbContext = appDbContext;
        }

        public DbSet<Movie> Table => _appDbContext.Set<Movie>();

        public int SaveChanges()
            => _appDbContext.SaveChanges();

        public async Task<int> SaveChangesAsync()
            => await _appDbContext.SaveChangesAsync();
    }
}
