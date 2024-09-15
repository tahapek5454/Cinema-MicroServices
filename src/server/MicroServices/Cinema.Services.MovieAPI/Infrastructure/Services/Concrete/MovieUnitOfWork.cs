using Cinema.Services.MovieAPI.Persistence.Data.Contexts;
using SharedLibrary.Services;

namespace Cinema.Services.MovieAPI.Infrastructure.Services.Concrete
{
    public class MovieUnitOfWork : BaseUnitOfWork
    {
        public MovieUnitOfWork(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
