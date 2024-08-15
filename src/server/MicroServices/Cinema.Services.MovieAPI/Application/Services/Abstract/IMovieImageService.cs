using Cinema.Services.MovieAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.MovieAPI.Application.Services.Abstract
{
    public interface IMovieImageService : IBaseService
    {
        public DbSet<MovieImage> Table { get; }
        public Task<int> SaveChangesAsync();
        public int SaveChanges();
    }
}
