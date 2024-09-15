using Cinema.Services.SessionAPI.Application.Repositories;
using Cinema.Services.SessionAPI.Application.Services.Abstract;
using Cinema.Services.SessionAPI.Domain.Entities;
using SharedLibrary.Services;

namespace Cinema.Services.SessionAPI.Infrastructure.Services.Concrete
{
    public class SeatSessionStatusService : BaseEntityService<SeatSessionStatus>, ISeatSessionStatusService
    {
        public SeatSessionStatusService(IHttpClientFactory _httpClientFactory, ISeatSessionStatusRepository repository) : base(_httpClientFactory, repository)
        {
        }
    }
}
