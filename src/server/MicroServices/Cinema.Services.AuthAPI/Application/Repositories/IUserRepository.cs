using Cinema.Services.AuthAPI.Domain.Entities;
using SharedLibrary.Repositories;

namespace Cinema.Services.AuthAPI.Application.Repositories
{
    public interface IUserRepository: IBaseRepository<User>
    {
    }
}
