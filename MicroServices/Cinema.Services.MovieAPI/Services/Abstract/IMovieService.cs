using Cinema.Services.MovieAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.MovieAPI.Services.Abstract
{
    public interface IMovieService: IBaseService
    {
        public DbSet<Movie> Table { get;}
        public Task<int> SaveChangesAsync();
        public int SaveChanges();
    }
}
