using MediatR;

namespace Cinema.Services.CategoryAPI.Application.Queries.Categories.GetAllCategories
{
    public class GetAllCategoriesRequest: IRequest<List<GetAllCategoriesResponse>>
    {
    }
}
