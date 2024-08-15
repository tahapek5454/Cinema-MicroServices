using Cinema.Services.CategoryAPI.Data.Contexts;
using Cinema.Services.CategoryAPI.Models.Entities;
using Cinema.Services.CategoryAPI.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.CategoryAPI.Services.Concrete
{
    public class CategoryService: BaseService, ICategoryService
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
