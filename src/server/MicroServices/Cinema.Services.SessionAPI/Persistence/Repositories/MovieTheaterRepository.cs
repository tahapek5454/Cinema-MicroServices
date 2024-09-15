using Cinema.Services.SessionAPI.Application.Repositories;
using Cinema.Services.SessionAPI.Domain.Entities;
using Cinema.Services.SessionAPI.Persistence.Data.Contexts;
using SharedLibrary.Repositories;

namespace Cinema.Services.SessionAPI.Persistence.Repositories
{
    public class MovieTheaterRepository : BaseRepository<MovieTheater>, IMovieTheaterRepository
    {
        public MovieTheaterRepository(AppDbContext context) : base(context)
        {
        }
    }
}
