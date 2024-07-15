using Cinema.Services.BranchAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.BranchAPI.Services.Abstract
{
    public interface IBranchService: IBaseService
    {
        public DbSet<Branch> Table { get; }
        public Task<int> SaveChangesAsync();
        public int SaveChanges();
    }
}
