using Cinema.Services.BranchAPI.Persistence.Data.Context;

namespace Cinema.Services.BranchAPI.Infrastructure.Services.Concrete
{
    public class BranchUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public BranchUnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int SaveChanges()
             => _dbContext.SaveChanges();

        public async Task<int> SaveChangesAsync()
            => await _dbContext.SaveChangesAsync();
    }
}
