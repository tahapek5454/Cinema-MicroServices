using Cinema.Services.FileAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.FileAPI.Application.Services.Abstract
{
    public interface IMovieImageService
    {
        public DbSet<MovieImage> Table { get; }
        public Task<int> SaveChangesAsync();
        public int SaveChanges();
    }
}
