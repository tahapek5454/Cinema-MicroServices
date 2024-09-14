using Cinema.Services.AuthAPI.Persistence.Data.Contexts;

namespace Cinema.Services.AuthAPI.Infrastructure.Services.Concrete
{
    public class AuthUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public AuthUnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public int SaveChanges()
            => _appDbContext.SaveChanges();

        public async Task<int> SaveChangesAsync()
            => await _appDbContext.SaveChangesAsync();
    }
}
