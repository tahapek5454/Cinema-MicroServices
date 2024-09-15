using Cinema.Services.SessionAPI.Application.Repositories;
using Cinema.Services.SessionAPI.Application.Services.Abstract;
using Cinema.Services.SessionAPI.Domain.Entities;
using SharedLibrary.Services;

namespace Cinema.Services.SessionAPI.Infrastructure.Services.Concrete
{
    public class SeatService : BaseEntityService<Seat>, ISeatService
    {
        public SeatService(IHttpClientFactory _httpClientFactory, ISeatRepository repository) : base(_httpClientFactory, repository)
        {
        }
    }
}
