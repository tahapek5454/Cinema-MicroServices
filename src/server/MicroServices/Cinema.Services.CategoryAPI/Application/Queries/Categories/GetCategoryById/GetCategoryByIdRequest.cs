using MediatR;

namespace Cinema.Services.CategoryAPI.Application.Queries.Categories.GetCategoryById
{
    public class GetCategoryByIdRequest: IRequest<GetCategoryByIdResponse>
    {
        public int Id { get; set; }
    }
}
