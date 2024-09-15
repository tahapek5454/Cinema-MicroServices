using Cinema.Services.BranchAPI.Persistence.Data.Context;
using SharedLibrary.Services;

namespace Cinema.Services.BranchAPI.Infrastructure.Services.Concrete
{
    public class BranchUnitOfWork : BaseUnitOfWork
    {
        public BranchUnitOfWork(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
