using Cinema.Services.AuthAPI.Application.Repositories;
using Cinema.Services.AuthAPI.Application.Services.Abstract;
using Cinema.Services.AuthAPI.Domain.Entities;
using SharedLibrary.Services;

namespace Cinema.Services.AuthAPI.Infrastructure.Services.Concrete
{
    public class UserService : BaseEntityService<User>, IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IHttpClientFactory _httpClientFactory, IUserRepository repository) : base(_httpClientFactory, repository)
        {
            _repository = repository;
        }
    }
}
