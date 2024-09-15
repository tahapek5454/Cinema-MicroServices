using MediatR;

namespace Cinema.Services.CategoryAPI.Application.Commands.Categories.UpdateGategory
{
    public class UpdateGategoryRequest: IRequest<UpdateGategoryResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name_EN { get; set; }
    }
}
