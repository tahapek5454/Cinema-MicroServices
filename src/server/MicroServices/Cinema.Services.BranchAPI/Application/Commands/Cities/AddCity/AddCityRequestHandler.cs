using Cinema.Services.BranchAPI.Application.Mapper;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using Cinema.Services.BranchAPI.Domain.Entities;
using Cinema.Services.BranchAPI.Infrastructure.Services.Concrete;
using MediatR;

namespace Cinema.Services.BranchAPI.Application.Commands.Cities.AddCity
{
    public class AddCityRequestHandler(ICityService _cityService, BranchUnitOfWork _branchUnitOfWork) : IRequestHandler<AddCityRequest, AddCityResponse>
    {
        public async Task<AddCityResponse> Handle(AddCityRequest request, CancellationToken cancellationToken)
        {
            var r = ObjectMapper.Mapper.Map<City>(request);

            await _cityService.Table.AddAsync(r);
            await _branchUnitOfWork.SaveChangesAsync();

            return new();
        }
    }
}
