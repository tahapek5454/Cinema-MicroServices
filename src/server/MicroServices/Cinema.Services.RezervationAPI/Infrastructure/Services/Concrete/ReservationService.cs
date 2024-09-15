using Cinema.Services.RezervationAPI.Application.Repositories;
using Cinema.Services.RezervationAPI.Application.Services.Abstract;
using Cinema.Services.RezervationAPI.Domain.Entities;
using SharedLibrary.Services;

namespace Cinema.Services.RezervationAPI.Infrastructure.Services.Concrete
{
    public class ReservationService : BaseEntityService<Reservation>, IReservationService
    {
        public ReservationService(IHttpClientFactory _httpClientFactory, IReservationRepository repository) : base(_httpClientFactory, repository)
        {
        }
    }
}
