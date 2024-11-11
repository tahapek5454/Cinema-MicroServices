using MediatR;

namespace Cinema.Services.BranchAPI.Application.Queries.Branches.GetBranchesByDistrinct
{
    public class GetBranchesByDistrinctRequest : IRequest<List<GetBranchesByDistrinctResponse>>
    {
        public int DistrinctId { get; set; }
    }
}
