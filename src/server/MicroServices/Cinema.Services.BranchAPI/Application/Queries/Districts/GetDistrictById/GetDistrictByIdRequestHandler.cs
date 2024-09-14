using Cinema.Services.BranchAPI.Application.Dtos;
using Cinema.Services.BranchAPI.Application.Mapper;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.BranchAPI.Application.Queries.Districts.GetDistrictById
{
    public class GetDistrictByIdRequestHandler(IDistrictService _districtService) : IRequestHandler<GetDistrictByIdRequest, GetDistrictByIdResponse>
    {
        public async Task<GetDistrictByIdResponse> Handle(GetDistrictByIdRequest request, CancellationToken cancellationToken)
        {
            var r = await _districtService.Table
                                       .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (r is null)
                throw new Exception("İlçe bulunamadı.");

            var result = ObjectMapper.Mapper.Map<DistrictDto>(r);

            return new()
            {
                CityId = result.CityId,
                Id = result.Id,
                Name = result.Name,
            };
        }
    }
}
