using Cinema.Services.SessionAPI.Application.Repositories;
using Cinema.Services.SessionAPI.Domain.Entities;
using Cinema.Services.SessionAPI.Persistence.Data.Contexts;
using SharedLibrary.Repositories;

namespace Cinema.Services.SessionAPI.Persistence.Repositories
{
    public class SeatSessionStatusRepository : BaseRepository<SeatSessionStatus>, ISeatSessionStatusRepository
    {
        public SeatSessionStatusRepository(AppDbContext context) : base(context)
        {
        }
    }
}
