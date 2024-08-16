using Cinema.Services.BranchAPI.Application.Services.Abstract;
using Cinema.Services.BranchAPI.Domain.Entities;
using Cinema.Services.BranchAPI.Persistence.Data.Context;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.BranchAPI.Infrastructure.Services.Concrete
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
