using Cinema.Services.CategoryAPI.Persistence.Data.Contexts;
using SharedLibrary.Services;

namespace Cinema.Services.CategoryAPI.Infrastructure.Services.Concrete
{
    public class CategoryUnitOfWork : BaseUnitOfWork
    {
        public CategoryUnitOfWork(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
