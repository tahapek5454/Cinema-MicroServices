using Cinema.Services.MovieAPI.Application.Repositories;
using Cinema.Services.MovieAPI.Domain.Entities;
using Cinema.Services.MovieAPI.Persistence.Data.Contexts;
using SharedLibrary.Repositories;

namespace Cinema.Services.MovieAPI.Persistence.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext context) : base(context)
        {
        }
    }
}
