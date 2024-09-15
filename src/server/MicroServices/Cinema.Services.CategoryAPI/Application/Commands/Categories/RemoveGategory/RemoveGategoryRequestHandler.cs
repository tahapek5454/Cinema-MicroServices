using Cinema.Services.CategoryAPI.Application.Services.Abstract;
using Cinema.Services.CategoryAPI.Infrastructure.Services.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.CategoryAPI.Application.Commands.Categories.RemoveGategory
{
    public class RemoveGategoryRequestHandler(ICategoryService _categoryService, CategoryUnitOfWork _categoryUnitOfWork) : IRequestHandler<RemoveGategoryRequest, RemoveGategoryResponse>
    {
        public async Task<RemoveGategoryResponse> Handle(RemoveGategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.Table.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (category is null)
                throw new Exception("Category is not found");

            _categoryService.Table.Remove(category);

            await _categoryUnitOfWork.SaveChangesAsync();

            return new();
        }
    }
}
