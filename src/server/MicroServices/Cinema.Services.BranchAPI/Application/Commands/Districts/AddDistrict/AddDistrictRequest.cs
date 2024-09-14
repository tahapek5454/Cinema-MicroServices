using MediatR;

namespace Cinema.Services.BranchAPI.Application.Commands.Districts.AddDistrict
{
    public class AddDistrictRequest: IRequest<AddDistrictResponse>
    {
        public string Name { get; set; }
        public int CityId { get; set; }
    }
}
