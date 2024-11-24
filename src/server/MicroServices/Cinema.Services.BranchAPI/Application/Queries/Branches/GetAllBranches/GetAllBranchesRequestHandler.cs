using Cinema.Services.BranchAPI.Application.Dtos;
using Cinema.Services.BranchAPI.Application.Mapper;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.BranchAPI.Application.Queries.Branches.GetAllBranches
{
    public class GetAllBranchesRequestHandler(IBranchService _branchService) : IRequestHandler<GetAllBranchesRequest, List<GetAllBranchesResponse>>
    {
        public async Task<List<GetAllBranchesResponse>> Handle(GetAllBranchesRequest request, CancellationToken cancellationToken)
        {
            var r = await _branchService.Table.Include(x => x.District).ThenInclude(x => x.City).ToListAsync();

            var result = ObjectMapper.Mapper.Map<List<BranchDto>>(r);

            return result?.Select(x => new GetAllBranchesResponse()
            {
                Address = x.Address,
                Description = x.Description,
                DistrictId = x.DistrictId,
                Id = x.Id,
                Name = x.Name,
                District = x.District,
                
            }).ToList() ?? new();
        }
    }
}
