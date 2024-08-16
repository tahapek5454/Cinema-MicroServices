using Cinema.Services.AuthAPI.Application.Dtos;
using Cinema.Services.AuthAPI.Domain.Entities;

namespace Cinema.Services.AuthAPI.Application.Services.Abstract
{
    public interface ITokenService
    {
        Task<LoginResponse> CreateTokenAsync(User user);

    }
}
