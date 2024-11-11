using MediatR;

namespace Cinema.Services.BranchAPI.Application.Queries.Districts.GetDistrictsByCity
{
    public class GetDistrictsByCityRequest : IRequest<List<GetDistrictsByCityResponse>>
    {
        public int CityId { get; set; }
    }
}
