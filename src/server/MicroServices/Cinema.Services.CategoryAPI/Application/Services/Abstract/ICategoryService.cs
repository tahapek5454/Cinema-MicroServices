using Cinema.Services.CategoryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.CategoryAPI.Application.Services.Abstract
{
    public interface ICategoryService : IBaseService
    {
        public DbSet<Category> Table { get; }
        public Task<int> SaveChangesAsync();
        public int SaveChanges();
    }
}
