using Cinema.Services.MovieAPI.Application.Services.Abstract;
using Cinema.Services.MovieAPI.Domain.Entities;
using Cinema.Services.MovieAPI.Persistence.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.MovieAPI.Infrastructure.Services.Concrete;

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

