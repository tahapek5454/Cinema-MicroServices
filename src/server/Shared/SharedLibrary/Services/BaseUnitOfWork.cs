using Microsoft.EntityFrameworkCore;

namespace SharedLibrary.Services
{
    public class BaseUnitOfWork
    {
        private readonly DbContext _dbContext;

        public BaseUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int SaveChanges()
             => _dbContext.SaveChanges();

        public async Task<int> SaveChangesAsync()
            => await _dbContext.SaveChangesAsync();
    }
}
