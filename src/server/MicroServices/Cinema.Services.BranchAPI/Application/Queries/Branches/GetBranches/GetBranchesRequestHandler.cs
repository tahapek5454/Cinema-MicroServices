using Cinema.Services.BranchAPI.Application.Dtos;
using Cinema.Services.BranchAPI.Application.Mapper;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.BranchAPI.Application.Queries.Branches.GetBranches
{
    public class GetBranchesRequestHandler(IBranchService _branchService) : IRequestHandler<GetBranchesRequest, List<GetBranchesResponse>>
    {
        public async Task<List<GetBranchesResponse>> Handle(GetBranchesRequest request, CancellationToken cancellationToken)
        {
            var r = await _branchService.Table
            .Skip((request.Page - 1) * request.Size).Take(request.Size).ToListAsync();

            var result = ObjectMapper.Mapper.Map<List<BranchDto>>(r);

            return result?.Select(x => new GetBranchesResponse()
            {
                Address = x.Address,
                Description = x.Description,
                DistrictId = x.DistrictId,
                Id = x.Id,
                Name = x.Name,
            }).ToList() ?? new();

        }
    }
}
