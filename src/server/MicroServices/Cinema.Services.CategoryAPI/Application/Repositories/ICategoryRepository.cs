using Cinema.Services.CategoryAPI.Domain.Entities;
using SharedLibrary.Repositories;

namespace Cinema.Services.CategoryAPI.Application.Repositories
{
    public interface ICategoryRepository: IBaseRepository<Category>
    {
    }
}
