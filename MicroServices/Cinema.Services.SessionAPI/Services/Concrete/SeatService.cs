using Cinema.Services.SessionAPI.Data.Contexts;
using Cinema.Services.SessionAPI.Models.Entities;
using Cinema.Services.SessionAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.SessionAPI.Services.Concrete
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
