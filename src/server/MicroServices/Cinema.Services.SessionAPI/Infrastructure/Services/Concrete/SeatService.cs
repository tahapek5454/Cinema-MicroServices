using Cinema.Services.SessionAPI.Application.Services.Abstract;
using Cinema.Services.SessionAPI.Domain.Entities;
using Cinema.Services.SessionAPI.Persistence.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.SessionAPI.Infrastructure.Services.Concrete
{
    public class SeatService : BaseService, ISeatService
    {
        private readonly AppDbContext _appDbContext;
        public SeatService(IHttpClientFactory _httpClientFactory, AppDbContext appDbContext) : base(_httpClientFactory)
        {
            _appDbContext = appDbContext;
        }

        public DbSet<Seat> Table => _appDbContext.Set<Seat>();

        public int SaveChanges()
            => _appDbContext.SaveChanges();

        public async Task<int> SaveChangesAsync()
            => await _appDbContext.SaveChangesAsync();
    }
}
