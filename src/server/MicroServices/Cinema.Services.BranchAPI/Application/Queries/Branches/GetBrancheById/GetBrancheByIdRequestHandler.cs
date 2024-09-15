using Cinema.Services.BranchAPI.Application.Dtos;
using Cinema.Services.BranchAPI.Application.Mapper;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.BranchAPI.Application.Queries.Branches.GetBrancheById
{
    public class GetBrancheByIdRequestHandler(IBranchService _branchService) : IRequestHandler<GetBrancheByIdRequest, GetBrancheByIdResponse>
    {
        public async Task<GetBrancheByIdResponse> Handle(GetBrancheByIdRequest request, CancellationToken cancellationToken)
        {
            var r = await _branchService.Table
                                        .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (r is null)
                throw new Exception("Şube bulunamadı.");

            var result = ObjectMapper.Mapper.Map<BranchDto>(r);

            return new()
            {
                Address = result.Address,
                Id = result.Id,
                Description = result.Description,
                DistrictId = result.DistrictId,
                Name = result.Name,
            };
        }
    }
}
