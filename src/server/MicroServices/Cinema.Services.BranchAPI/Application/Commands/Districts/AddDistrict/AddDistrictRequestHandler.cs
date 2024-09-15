using Cinema.Services.BranchAPI.Application.Mapper;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using Cinema.Services.BranchAPI.Domain.Entities;
using Cinema.Services.BranchAPI.Infrastructure.Services.Concrete;
using MediatR;

namespace Cinema.Services.BranchAPI.Application.Commands.Districts.AddDistrict
{
    public class AddDistrictRequestHandler(IDistrictService _districtService, BranchUnitOfWork _branchUnitOfWork) : IRequestHandler<AddDistrictRequest, AddDistrictResponse>
    {
        public async Task<AddDistrictResponse> Handle(AddDistrictRequest request, CancellationToken cancellationToken)
        {
            var r = ObjectMapper.Mapper.Map<District>(request);

            await _districtService.Table.AddAsync(r);
            await _branchUnitOfWork.SaveChangesAsync();

            return new();
        }
    }
}
