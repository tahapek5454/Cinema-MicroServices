using Cinema.Services.MovieAPI.Application.Repositories;
using Cinema.Services.MovieAPI.Domain.Entities;
using Cinema.Services.MovieAPI.Persistence.Data.Contexts;
using SharedLibrary.Repositories;

namespace Cinema.Services.MovieAPI.Persistence.Repositories
{
    public class MovieImageRepository : BaseRepository<MovieImage>, IMovieImageRepository
    {
        private readonly AppDbContext _appDbContext;
        public MovieImageRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }
    }
}
