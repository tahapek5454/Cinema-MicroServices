using Cinema.Services.SessionAPI.Persistence.Data.Contexts;
using SharedLibrary.Services;

namespace Cinema.Services.SessionAPI.Infrastructure.Services.Concrete
{
    public class SessionUnitOfWork : BaseUnitOfWork
    {
        public SessionUnitOfWork(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
