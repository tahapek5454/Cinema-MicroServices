using Cinema.Services.CategoryAPI.Application.Dtos.Categories;
using Cinema.Services.CategoryAPI.Application.Mapper;
using Cinema.Services.CategoryAPI.Application.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.CategoryAPI.Application.Queries.Categories.GetCategoriesWithPagination
{
    public class GetCategoriesWithPaginationRequestHandler(ICategoryService _categoryService) : IRequestHandler<GetCategoriesWithPaginationRequest, List<GetCategoriesWithPaginationResponse>>
    {
        public async Task<List<GetCategoriesWithPaginationResponse>> Handle(GetCategoriesWithPaginationRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.Table
                .Skip((request.Page - 1) * request.Size)
                .Take(request.Size)
                .ToListAsync();

            var categoryDtos = ObjectMapper.Mapper.Map<List<CategoryDto>>(categories);

            return categoryDtos?.Select(x => new GetCategoriesWithPaginationResponse()
            {
                CreatedDate = x.CreatedDate,
                Id = x.Id,
                Name = x.Name
            }).ToList() ?? new List<GetCategoriesWithPaginationResponse>();
        }
    }
}
