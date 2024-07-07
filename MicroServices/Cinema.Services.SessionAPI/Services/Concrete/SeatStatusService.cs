using Cinema.Services.SessionAPI.Data.Contexts;
using Cinema.Services.SessionAPI.Models.Entities;
using Cinema.Services.SessionAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.SessionAPI.Services.Concrete
{
    public class SeatStatusService : BaseService, ISeatStatusService
    {
        private readonly AppDbContext _appDbContext;
        public SeatStatusService(IHttpClientFactory _httpClientFactory, AppDbContext appDbContext) : base(_httpClientFactory)
        {
            _appDbContext = appDbContext;
        }

        public DbSet<SeatStatus> Table => _appDbContext.Set<SeatStatus>();

        public int SaveChanges()
            => _appDbContext.SaveChanges();

        public async Task<int> SaveChangesAsync()
            => await _appDbContext.SaveChangesAsync();
    }
}
