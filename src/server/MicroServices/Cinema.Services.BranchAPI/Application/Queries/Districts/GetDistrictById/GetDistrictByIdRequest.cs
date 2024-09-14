using MediatR;

namespace Cinema.Services.BranchAPI.Application.Queries.Districts.GetDistrictById
{
    public class GetDistrictByIdRequest : IRequest<GetDistrictByIdResponse>
    {
        public int Id { get; set; }
    }
}
