using Cinema.Services.SessionAPI.Application.Repositories;
using Cinema.Services.SessionAPI.Application.Services.Abstract;
using Cinema.Services.SessionAPI.Domain.Entities;
using SharedLibrary.Services;

namespace Cinema.Services.SessionAPI.Infrastructure.Services.Concrete
{
    public class SessionService : BaseEntityService<Session>, ISessionService
    {
        public SessionService(IHttpClientFactory _httpClientFactory,ISessionRepository repository) : base(_httpClientFactory, repository)
        {
        }
    }
}
