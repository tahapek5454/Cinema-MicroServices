using Cinema.Services.CategoryAPI.Application.Dtos.Categories;
using Cinema.Services.CategoryAPI.Application.Mapper;
using Cinema.Services.CategoryAPI.Application.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.CategoryAPI.Application.Queries.Categories.GetAllCategories
{
    public class GetAllCategoriesRequestHandler(ICategoryService _categoryService) : IRequestHandler<GetAllCategoriesRequest, List<GetAllCategoriesResponse>>
    {
        public async Task<List<GetAllCategoriesResponse>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.Table.ToListAsync();

            var categoryDtos = ObjectMapper.Mapper.Map<List<CategoryDto>>(categories);

            return categoryDtos?.Select(x => new GetAllCategoriesResponse()
            {
                CreatedDate = x.CreatedDate,
                Id = x.Id,
                Name = x.Name
            }).ToList() ?? new();
        }
    }
}
