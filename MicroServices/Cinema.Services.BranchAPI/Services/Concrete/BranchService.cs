using Cinema.Services.BranchAPI.Data.Context;
using Cinema.Services.BranchAPI.Models.Entities;
using Cinema.Services.BranchAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.BranchAPI.Services.Concrete
{
    public class BranchService : BaseService, IBranchService
    {
        private readonly AppDbContext _appDbContext;
        public BranchService(IHttpClientFactory _httpClientFactory, AppDbContext appDbContext) : base(_httpClientFactory)
        {
            _appDbContext = appDbContext;
        }

        public DbSet<Branch> Table => _appDbContext.Set<Branch>();

        public int SaveChanges()
            => _appDbContext.SaveChanges();

        public async Task<int> SaveChangesAsync()
            => await _appDbContext.SaveChangesAsync();
    }
}
