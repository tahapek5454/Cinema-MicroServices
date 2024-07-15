using Cinema.Services.BranchAPI.Data.Context;
using Cinema.Services.BranchAPI.Models.Entities;
using Cinema.Services.BranchAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.BranchAPI.Services.Concrete
{
    public class CityService : BaseService, ICityService
    {
        private readonly AppDbContext _appDbContext;
        public CityService(IHttpClientFactory _httpClientFactory, AppDbContext appDbContext) : base(_httpClientFactory)
        {
            _appDbContext = appDbContext;
        }

        public DbSet<City> Table => _appDbContext.Set<City>();

        public int SaveChanges()
            => _appDbContext.SaveChanges(); 

        public async Task<int> SaveChangesAsync()
            => await _appDbContext.SaveChangesAsync();  
    }
}
