using Cinema.Services.BranchAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.BranchAPI.Services.Abstract
{
    public interface ICityService: IBaseService
    {
        public DbSet<City> Table { get; }
        public Task<int> SaveChangesAsync();
        public int SaveChanges();
    }
}
