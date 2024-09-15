using Cinema.Services.CategoryAPI.Application.Mapper;
using Cinema.Services.CategoryAPI.Application.Services.Abstract;
using Cinema.Services.CategoryAPI.Domain.Entities;
using Cinema.Services.CategoryAPI.Infrastructure.Services.Concrete;
using MediatR;

namespace Cinema.Services.CategoryAPI.Application.Commands.Categories.UpdateGategory
{
    public class UpdateGategoryRequestHandler(ICategoryService _categoryService, CategoryUnitOfWork _categoryUnitOfWork) : IRequestHandler<UpdateGategoryRequest, UpdateGategoryResponse>
    {
        public async Task<UpdateGategoryResponse> Handle(UpdateGategoryRequest request, CancellationToken cancellationToken)
        {
            var updatedCategory = ObjectMapper.Mapper.Map<Category>(request);

            _categoryService.Table.Update(updatedCategory);

            await _categoryUnitOfWork.SaveChangesAsync();

            return new();
        }
    }
}
