using Cinema.Services.FileAPI.Persistence.Data.Contexts;
using SharedLibrary.Services;

namespace Cinema.Services.FileAPI.Infrastructure.Services.Concrete
{
    public class FileUnitOfWork : BaseUnitOfWork
    {
        public FileUnitOfWork(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
