using Cinema.Services.SessionAPI.Application.Repositories;
using Cinema.Services.SessionAPI.Domain.Entities;
using Cinema.Services.SessionAPI.Persistence.Data.Contexts;
using SharedLibrary.Repositories;

namespace Cinema.Services.SessionAPI.Persistence.Repositories
{
    public class SessionRepository : BaseRepository<Session>, ISessionRepository
    {
        public SessionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
