using MediatR;

namespace Cinema.Services.BranchAPI.Application.Queries.Districts.GetAllDistricts
{
    public class GetAllDistrictsRequest: IRequest<List<GetAllDistrictsResponse>>
    {
    }
}
