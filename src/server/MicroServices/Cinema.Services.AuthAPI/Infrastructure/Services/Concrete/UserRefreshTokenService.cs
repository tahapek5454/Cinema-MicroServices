using Cinema.Services.AuthAPI.Application.Repositories;
using Cinema.Services.AuthAPI.Application.Services.Abstract;
using Cinema.Services.AuthAPI.Domain.Entities;
using SharedLibrary.Services;

namespace Cinema.Services.AuthAPI.Infrastructure.Services.Concrete
{
    public class UserRefreshTokenService : BaseEntityService<UserRefreshToken>, IUserRefreshTokenService
    {
        private readonly IUserRefreshTokenRepository _repository;
        public UserRefreshTokenService(IHttpClientFactory _httpClientFactory, IUserRefreshTokenRepository repository) : base(_httpClientFactory, repository)
        {
            _repository = repository;
        }
    }
}
