using Cinema.Services.BranchAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.BranchAPI.Application.Services.Abstract
{
    public interface IBranchService : IBaseService
    {
        public DbSet<Branch> Table { get; }
        public Task<int> SaveChangesAsync();
        public int SaveChanges();
    }
}
