using Cinema.Services.BranchAPI.Application.Dtos;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using Cinema.Services.BranchAPI.Application.Mapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.BranchAPI.Application.Queries.Branches.GetBranchesByDistrinct
{
    public class GetBranchesByDistrinctRequestHandler(IBranchService _branchService) : IRequestHandler<GetBranchesByDistrinctRequest, List<GetBranchesByDistrinctResponse>>
    {
        public async Task<List<GetBranchesByDistrinctResponse>> Handle(GetBranchesByDistrinctRequest request, CancellationToken cancellationToken)
        {
            var r = await _branchService.Table.Where(x => x.DistrictId == request.DistrinctId).ToListAsync();

            var result = ObjectMapper.Mapper.Map<List<BranchDto>>(r);

            return result?.Select(x => new GetBranchesByDistrinctResponse()
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
