using Cinema.Services.RezervationAPI.Domain.Entities;
using SharedLibrary.Repositories;

namespace Cinema.Services.RezervationAPI.Application.Repositories
{
    public interface IReservationRepository: IBaseRepository<Reservation>
    {
    }
}
