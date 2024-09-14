using MediatR;

namespace Cinema.Services.BranchAPI.Application.Queries.Districts.GetDistricts
{
    public class GetDistrictsRequest: IRequest<List<GetDistrictsResponse>>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
    }
}
