using Cinema.Services.RezervationAPI.Application.Services.Abstract;
using Cinema.Services.RezervationAPI.Domain.Entities;
using Cinema.Services.RezervationAPI.Persistence.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.RezervationAPI.Infrastructure.Services.Concrete
{
    public class ReservationService : BaseService, IReservationService
    {
        private readonly AppDbContext _appDbContext;
        public ReservationService(IHttpClientFactory _httpClientFactory, AppDbContext appDbContext) : base(_httpClientFactory)
        {
            _appDbContext = appDbContext;
        }

        public DbSet<Reservation> Table => _appDbContext.Set<Reservation>();

        public int SaveChanges()
        {
            return _appDbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
