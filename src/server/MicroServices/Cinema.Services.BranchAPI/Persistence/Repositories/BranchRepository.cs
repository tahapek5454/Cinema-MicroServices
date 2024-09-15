using Cinema.Services.BranchAPI.Application.Repositories;
using Cinema.Services.BranchAPI.Domain.Entities;
using Cinema.Services.BranchAPI.Persistence.Data.Context;
using SharedLibrary.Repositories;

namespace Cinema.Services.BranchAPI.Persistence.Repositories
{
    public class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        private readonly AppDbContext _appDbContext;
        public BranchRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }
    }
}
