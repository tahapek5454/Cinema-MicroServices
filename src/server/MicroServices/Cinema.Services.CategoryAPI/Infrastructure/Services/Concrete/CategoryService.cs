using Cinema.Services.CategoryAPI.Application.Repositories;
using Cinema.Services.CategoryAPI.Application.Services.Abstract;
using Cinema.Services.CategoryAPI.Domain.Entities;
using SharedLibrary.Services;

namespace Cinema.Services.CategoryAPI.Infrastructure.Services.Concrete
{
    public class CategoryService : BaseEntityService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IHttpClientFactory _httpClientFactory, ICategoryRepository repository) : base(_httpClientFactory, repository)
        {
            _categoryRepository = repository;
        }
    }
}
