using MediatR;

namespace Cinema.Services.BranchAPI.Application.Queries.Branches.GetAllBranches
{
    public class GetAllBranchesRequest: IRequest<List<GetAllBranchesResponse>>
    {
    }
}
