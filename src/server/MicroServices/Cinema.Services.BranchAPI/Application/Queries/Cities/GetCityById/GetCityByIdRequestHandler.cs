using Cinema.Services.BranchAPI.Application.Dtos;
using Cinema.Services.BranchAPI.Application.Mapper;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.BranchAPI.Application.Queries.Cities.GetCityById
{
    public class GetCityByIdRequestHandler(ICityService _cityService) : IRequestHandler<GetCityByIdRequest, GetCityByIdResponse>
    {
        public async Task<GetCityByIdResponse> Handle(GetCityByIdRequest request, CancellationToken cancellationToken)
        {
            var r = await _cityService.Table
                                        .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (r is null)
                throw new Exception("Şehir bulunamadı.");

            var result = ObjectMapper.Mapper.Map<CityDto>(r);

            return new()
            {
                Id = result.Id,
                Name = result.Name,
            };
        }
    }
}
