using MediatR;

namespace Cinema.Services.CategoryAPI.Application.Queries.Categories.GetCategoriesWithPagination
{
    public class GetCategoriesWithPaginationRequest: IRequest<List<GetCategoriesWithPaginationResponse>>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
    }
}
