using Cinema.Services.AuthAPI.Models.Dtos;
using Cinema.Services.AuthAPI.Models.Entities;

namespace Cinema.Services.AuthAPI.Services.Abstract
{
    public interface ITokenService
    {
        Task<LoginResponse> CreateTokenAsync(User user);

    }
}
