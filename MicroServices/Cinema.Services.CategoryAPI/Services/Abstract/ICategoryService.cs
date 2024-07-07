using Cinema.Services.CategoryAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.CategoryAPI.Services.Abstract
{
    public interface ICategoryService: IBaseService
    {
        public DbSet<Category> Table { get; }
        public Task<int> SaveChangesAsync();
        public int SaveChanges();
    }
}
