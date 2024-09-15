using Cinema.Services.CategoryAPI.Application.Mapper;
using Cinema.Services.CategoryAPI.Application.Services.Abstract;
using Cinema.Services.CategoryAPI.Domain.Entities;
using Cinema.Services.CategoryAPI.Infrastructure.Services.Concrete;
using MediatR;

namespace Cinema.Services.CategoryAPI.Application.Commands.Categories.AddGategory
{
    public class AddCategoryRequestHandler(ICategoryService _categoryService, CategoryUnitOfWork _categoryUnitOfWork) : IRequestHandler<AddCategoryRequest, AddCategoryResponse>
    {
        public async Task<AddCategoryResponse> Handle(AddCategoryRequest request, CancellationToken cancellationToken)
        {
            var newCategory = ObjectMapper.Mapper.Map<Category>(request);

            await _categoryService.Table.AddAsync(newCategory);

            await _categoryUnitOfWork.SaveChangesAsync();

            return new();
        }
    }
}
