using Cinema.Services.BranchAPI.Application.Dtos;
using Cinema.Services.BranchAPI.Application.Mapper;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.BranchAPI.Application.Queries.Cities.GetCities
{
    public class GetCitiesRequestHandler(ICityService _cityService) : IRequestHandler<GetCitiesRequest, List<GetCitiesResponse>>
    {
        public async Task<List<GetCitiesResponse>> Handle(GetCitiesRequest request, CancellationToken cancellationToken)
        {
            var r = await _cityService.Table
            .Skip((request.Page - 1) * request.Size).Take(request.Size).ToListAsync();

            var result = ObjectMapper.Mapper.Map<List<CityDto>>(r);

            return result?.Select(x => new GetCitiesResponse()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList() ?? new();

        }
    }
}
