using Cinema.Services.BranchAPI.Application.Dtos;
using Cinema.Services.BranchAPI.Application.Mapper;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.BranchAPI.Application.Queries.Districts.GetAllDistricts
{
    public class GetAllDistrictsRequestHandler(IDistrictService _districtService) : IRequestHandler<GetAllDistrictsRequest, List<GetAllDistrictsResponse>>
    {
        public async Task<List<GetAllDistrictsResponse>> Handle(GetAllDistrictsRequest request, CancellationToken cancellationToken)
        {
            var r = await _districtService.Table.ToListAsync();

            var result = ObjectMapper.Mapper.Map<List<DistrictDto>>(r);

            return result?.Select(x => new GetAllDistrictsResponse()
            {
                CityId = x.CityId,
                Id = x.Id,
                Name = x.Name
            }).ToList() ?? new List<GetAllDistrictsResponse>();
        }
    }
}
