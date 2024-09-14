using Cinema.Services.BranchAPI.Application.Dtos;
using Cinema.Services.BranchAPI.Application.Mapper;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.BranchAPI.Application.Queries.Cities.GetAllCities
{
    public class GetAllCitiesRequestHandler(ICityService _cityService) : IRequestHandler<GetAllCitiesRequest, List<GetAllCitiesResponse>>
    {
        public async Task<List<GetAllCitiesResponse>> Handle(GetAllCitiesRequest request, CancellationToken cancellationToken)
        {
            var r = await _cityService.Table.ToListAsync();

            var result = ObjectMapper.Mapper.Map<List<CityDto>>(r);

            return result?.Select(x => new GetAllCitiesResponse()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList() ?? new List<GetAllCitiesResponse>();
        }
    }
}
