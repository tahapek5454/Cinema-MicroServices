using Cinema.Services.FileAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.FileAPI.Services.Abstract
{
    public interface IMovieImageService
    {
        public DbSet<MovieImage> Table { get; }
        public Task<int> SaveChangesAsync();
        public int SaveChanges();
    }
}
