using Cinema.Services.BranchAPI.Application.Mapper;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using Cinema.Services.BranchAPI.Infrastructure.Services.Concrete;
using MediatR;

namespace Cinema.Services.BranchAPI.Application.Commands.Branches.AddBranch
{
    public class AddBranchRequestHandler(IBranchService _branchService, BranchUnitOfWork _branchUnitOfWork) : IRequestHandler<AddBranchRequest, AddBranchResponse>
    {
        public async Task<AddBranchResponse> Handle(AddBranchRequest request, CancellationToken cancellationToken)
        {
            var r = ObjectMapper.Mapper.Map<Domain.Entities.Branch>(request);

            await _branchService.Table.AddAsync(r);
            await _branchUnitOfWork.SaveChangesAsync();

            return new();
        }
    }
}
