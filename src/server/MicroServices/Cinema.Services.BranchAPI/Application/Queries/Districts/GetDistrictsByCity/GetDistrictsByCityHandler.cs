using Cinema.Services.BranchAPI.Application.Dtos;
using Cinema.Services.BranchAPI.Application.Mapper;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.BranchAPI.Application.Queries.Districts.GetDistrictsByCity
{
    public class GetDistrictsByCityHandler(IDistrictService _districtService) : IRequestHandler<GetDistrictsByCityRequest, List<GetDistrictsByCityResponse>>
    {
        public async Task<List<GetDistrictsByCityResponse>> Handle(GetDistrictsByCityRequest request, CancellationToken cancellationToken)
        {
            var r = await _districtService.Table.Where(x => x.CityId == request.CityId).ToListAsync();

            var result = ObjectMapper.Mapper.Map<List<DistrictDto>>(r);

            return result?.Select(x => new GetDistrictsByCityResponse()
            {
                CityId = x.CityId,
                Id = x.Id,
                Name = x.Name
            }).ToList() ?? new List<GetDistrictsByCityResponse>();
        }
    }
}
