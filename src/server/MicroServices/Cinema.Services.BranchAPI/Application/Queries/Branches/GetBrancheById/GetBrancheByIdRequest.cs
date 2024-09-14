using MediatR;

namespace Cinema.Services.BranchAPI.Application.Queries.Branches.GetBrancheById
{
    public class GetBrancheByIdRequest: IRequest<GetBrancheByIdResponse>
    {
        public int Id { get; set; }
    }
}
