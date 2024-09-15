using MediatR;

namespace Cinema.Services.BranchAPI.Application.Commands.Cities.AddCity
{
    public class AddCityRequest: IRequest<AddCityResponse>
    {
        public string Name { get; set; }
    }
}
