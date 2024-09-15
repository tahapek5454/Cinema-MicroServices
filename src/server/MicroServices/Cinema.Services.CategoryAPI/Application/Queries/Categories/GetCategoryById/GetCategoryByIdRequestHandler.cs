using Cinema.Services.CategoryAPI.Application.Dtos.Categories;
using Cinema.Services.CategoryAPI.Application.Mapper;
using Cinema.Services.CategoryAPI.Application.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.CategoryAPI.Application.Queries.Categories.GetCategoryById
{
    public class GetCategoryByIdRequestHandler(ICategoryService _categoryService) : IRequestHandler<GetCategoryByIdRequest, GetCategoryByIdResponse>
    {
        public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.Table.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (category is null)
                throw new Exception("Category is not found");

            var categoryDto = ObjectMapper.Mapper.Map<CategoryDto>(category);

            return new()
            {
                CreatedDate = categoryDto.CreatedDate,
                Id = categoryDto.Id,
                Name = categoryDto.Name,
            };
        }
    }
}
