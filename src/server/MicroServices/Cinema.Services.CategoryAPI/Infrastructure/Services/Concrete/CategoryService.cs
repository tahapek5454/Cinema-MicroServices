using Cinema.Services.CategoryAPI.Application.Services.Abstract;
using Cinema.Services.CategoryAPI.Domain.Entities;
using Cinema.Services.CategoryAPI.Persistence.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.CategoryAPI.Infrastructure.Services.Concrete
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly AppDbContext _appDbContext;
        public CategoryService(IHttpClientFactory _httpClientFactory, AppDbContext appDbContext) : base(_httpClientFactory)
        {
            _appDbContext = appDbContext;
        }

        public DbSet<Category> Table => _appDbContext.Set<Category>();

        public int SaveChanges()
            => _appDbContext.SaveChanges();

        public async Task<int> SaveChangesAsync()
            => await _appDbContext.SaveChangesAsync();
    }
}
