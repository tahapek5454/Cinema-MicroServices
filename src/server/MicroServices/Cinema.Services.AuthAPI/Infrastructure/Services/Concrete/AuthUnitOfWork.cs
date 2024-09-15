using Cinema.Services.AuthAPI.Persistence.Data.Contexts;
using SharedLibrary.Services;

namespace Cinema.Services.AuthAPI.Infrastructure.Services.Concrete
{
    public class AuthUnitOfWork : BaseUnitOfWork
    {
        public AuthUnitOfWork(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
