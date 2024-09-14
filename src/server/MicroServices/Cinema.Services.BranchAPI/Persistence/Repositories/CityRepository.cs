using Cinema.Services.BranchAPI.Application.Repositories;
using Cinema.Services.BranchAPI.Domain.Entities;
using Cinema.Services.BranchAPI.Persistence.Data.Context;
using SharedLibrary.Repositories;

namespace Cinema.Services.BranchAPI.Persistence.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        private readonly AppDbContext _context;
        public CityRepository(AppDbContext context) : base(context)
        {
            _context = context; 
        }
    }
}
