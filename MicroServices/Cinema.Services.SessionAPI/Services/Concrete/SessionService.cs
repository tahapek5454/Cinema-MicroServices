using Cinema.Services.SessionAPI.Data.Contexts;
using Cinema.Services.SessionAPI.Models.Entities;
using Cinema.Services.SessionAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.SessionAPI.Services.Concrete
{
    public class SessionService : BaseService, ISessionService
    {
        private readonly AppDbContext _appDbContext;

        public SessionService(IHttpClientFactory _httpClientFactory, AppDbContext appDbContext) : base(_httpClientFactory)
        {
            _appDbContext = appDbContext;
        }

        public DbSet<Session> Table => _appDbContext.Set<Session>();

        public int SaveChanges()
            => _appDbContext.SaveChanges();

        public async Task<int> SaveChangesAsync()
            => await _appDbContext.SaveChangesAsync();
    }
}
