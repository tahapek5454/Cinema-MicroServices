using Cinema.Services.AuthAPI.Application.Repositories;
using Cinema.Services.AuthAPI.Domain.Entities;
using Cinema.Services.AuthAPI.Persistence.Data.Contexts;
using SharedLibrary.Repositories;

namespace Cinema.Services.AuthAPI.Persistence.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
