using Cinema.Services.AuthAPI.Application.Repositories;
using Cinema.Services.AuthAPI.Domain.Entities;
using Cinema.Services.AuthAPI.Persistence.Data.Contexts;
using SharedLibrary.Repositories;

namespace Cinema.Services.AuthAPI.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
