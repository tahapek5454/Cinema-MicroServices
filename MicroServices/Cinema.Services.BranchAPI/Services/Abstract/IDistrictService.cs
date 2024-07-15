using Cinema.Services.BranchAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.BranchAPI.Services.Abstract
{
    public interface IDistrictService: IBaseService
    {
        public DbSet<District> Table { get; }
        public Task<int> SaveChangesAsync();
        public int SaveChanges();
    }
}
