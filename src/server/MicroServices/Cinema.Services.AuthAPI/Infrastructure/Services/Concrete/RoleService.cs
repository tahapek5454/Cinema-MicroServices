using Cinema.Services.AuthAPI.Application.Repositories;
using Cinema.Services.AuthAPI.Application.Services.Abstract;
using Cinema.Services.AuthAPI.Domain.Entities;
using SharedLibrary.Services;

namespace Cinema.Services.AuthAPI.Infrastructure.Services.Concrete
{
    public class RoleService : BaseEntityService<Role>, IRoleService
    {
        private readonly IRoleRepository _repository;
        public RoleService(IHttpClientFactory _httpClientFactory, IRoleRepository repository) : base(_httpClientFactory, repository)
        {
            _repository = repository;
        }
    }
}
