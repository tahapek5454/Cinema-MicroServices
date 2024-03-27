using Cinema.Services.MovieAPI.Data.Contexts;
using Cinema.Services.MovieAPI.Models.Entities;
using Cinema.Services.MovieAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.MovieAPI.Services.Concrete;

public class MovieImageService : BaseService, IMovieImageService
{
    private readonly AppDbContext _dbContext;
    public MovieImageService(IHttpClientFactory _httpClientFactory, AppDbContext dbContext) : base(_httpClientFactory)
    {
        _dbContext = dbContext;
    }

    public DbSet<MovieImage> Table => _dbContext.Set<MovieImage>();

    public int SaveChanges()
        => _dbContext.SaveChanges();

    public async Task<int> SaveChangesAsync()
        => await _dbContext.SaveChangesAsync();
}

