using Cinema.Services.FileAPI.Application.Services.Abstract;
using Cinema.Services.FileAPI.Domain.Entities;
using Cinema.Services.FileAPI.Persistence.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.FileAPI.Infrastructure.Services.Concrete
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
