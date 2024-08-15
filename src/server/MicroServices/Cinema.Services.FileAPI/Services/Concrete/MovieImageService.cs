using Cinema.Services.FileAPI.Data.Contexts;
using Cinema.Services.FileAPI.Models;
using Cinema.Services.FileAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.FileAPI.Services.Concrete
{
    public class MovieImageService(AppDbContext appDbContext) : IMovieImageService
    {
        public DbSet<MovieImage> Table => appDbContext.Set<MovieImage>();

        public int SaveChanges()
            => appDbContext.SaveChanges();

        public async Task<int> SaveChangesAsync()
            => await appDbContext.SaveChangesAsync();
    }
}
