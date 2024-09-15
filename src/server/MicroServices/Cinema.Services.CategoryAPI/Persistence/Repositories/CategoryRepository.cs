using Cinema.Services.CategoryAPI.Application.Repositories;
using Cinema.Services.CategoryAPI.Domain.Entities;
using Cinema.Services.CategoryAPI.Persistence.Data.Contexts;
using SharedLibrary.Repositories;

namespace Cinema.Services.CategoryAPI.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }
    }
}
