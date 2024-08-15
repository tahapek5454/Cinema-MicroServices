using Cinema.Services.BranchAPI.Data.Context;
using Cinema.Services.BranchAPI.Models.Entities;
using Cinema.Services.BranchAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.BranchAPI.Services.Concrete
{
    public class DistrictService : BaseService, IDistrictService
    {
        private readonly AppDbContext _appDbContext;
        public DistrictService(IHttpClientFactory _httpClientFactory, AppDbContext appDbContext) : base(_httpClientFactory)
        {
            _appDbContext = appDbContext;
        }

        public DbSet<District> Table => _appDbContext.Set<District>();

        public int SaveChanges()
            => _appDbContext.SaveChanges();

        public async Task<int> SaveChangesAsync()
            => await _appDbContext.SaveChangesAsync();
    }
}
