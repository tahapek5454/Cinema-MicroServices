using Cinema.Services.RezervationAPI.Application.Repositories;
using Cinema.Services.RezervationAPI.Domain.Entities;
using Cinema.Services.RezervationAPI.Persistence.Data.Contexts;
using SharedLibrary.Repositories;

namespace Cinema.Services.RezervationAPI.Persistence.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
