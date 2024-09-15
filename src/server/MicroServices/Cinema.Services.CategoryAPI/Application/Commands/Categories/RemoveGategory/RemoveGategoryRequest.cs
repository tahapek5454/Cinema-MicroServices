using MediatR;

namespace Cinema.Services.CategoryAPI.Application.Commands.Categories.RemoveGategory
{
    public class RemoveGategoryRequest: IRequest<RemoveGategoryResponse>
    {
        public int Id { get; set; }
    }
}
