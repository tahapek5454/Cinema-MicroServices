using Cinema.Services.RezervationAPI.Persistence.Data.Contexts;
using SharedLibrary.Services;

namespace Cinema.Services.RezervationAPI.Infrastructure.Services.Concrete
{
    public class ReservationUnitOfWork : BaseUnitOfWork
    {
        public ReservationUnitOfWork(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
