using Cinema.Services.FileAPI.Application.Repositories;
using Cinema.Services.FileAPI.Domain.Entities;
using Cinema.Services.FileAPI.Persistence.Data.Contexts;
using SharedLibrary.Repositories;

namespace Cinema.Services.FileAPI.Persistence.Repositories
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
