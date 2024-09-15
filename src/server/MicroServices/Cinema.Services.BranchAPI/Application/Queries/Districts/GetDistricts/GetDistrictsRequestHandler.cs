using Cinema.Services.BranchAPI.Application.Dtos;
using Cinema.Services.BranchAPI.Application.Mapper;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.BranchAPI.Application.Queries.Districts.GetDistricts
{
    public class GetDistrictsRequestHandler(IDistrictService _districtService) : IRequestHandler<GetDistrictsRequest, List<GetDistrictsResponse>>
    {
        public async Task<List<GetDistrictsResponse>> Handle(GetDistrictsRequest request, CancellationToken cancellationToken)
        {
            var r = await _districtService.Table
            .Skip((request.Page - 1) * request.Size).Take(request.Size).ToListAsync();

            var result = ObjectMapper.Mapper.Map<List<DistrictDto>>(r);

            return result?.Select(x => new GetDistrictsResponse()
            {
                CityId = x.CityId,
                Id = x.Id,
                Name = x.Name
            }).ToList() ?? new List<GetDistrictsResponse>();
        }
    }
}
