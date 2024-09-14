using MediatR;

namespace Cinema.Services.BranchAPI.Application.Queries.Branches.GetBranches
{
    public class GetBranchesRequest: IRequest<List<GetBranchesResponse>>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
    }
}
