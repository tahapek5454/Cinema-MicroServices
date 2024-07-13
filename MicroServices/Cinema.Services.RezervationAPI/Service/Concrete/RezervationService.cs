using Cinema.Services.RezervationAPI.Data.Contexts;
using Cinema.Services.RezervationAPI.Models.Entities;
using Cinema.Services.RezervationAPI.Service.Abstract;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.RezervationAPI.Service.Concrete
{
    public class RezervationService : BaseService, IRezervationService
    {
        private readonly AppDbContext _appDbContext;
        public RezervationService(IHttpClientFactory _httpClientFactory, AppDbContext appDbContext) : base(_httpClientFactory)
        {
            _appDbContext = appDbContext;
        }

        public DbSet<Rezervation> Table => _appDbContext.Set<Rezervation>();

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
