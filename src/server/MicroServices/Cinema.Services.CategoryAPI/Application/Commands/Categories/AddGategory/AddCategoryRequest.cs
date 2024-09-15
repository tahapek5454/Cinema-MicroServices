using MediatR;

namespace Cinema.Services.CategoryAPI.Application.Commands.Categories.AddGategory
{
    public class AddCategoryRequest: IRequest<AddCategoryResponse>
    {
        public string Name { get; set; }
        public string Name_EN { get; set; }
    }
}
