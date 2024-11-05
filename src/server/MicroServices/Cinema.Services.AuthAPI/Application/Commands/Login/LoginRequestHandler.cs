using Cinema.Services.AuthAPI.Application.Services.Abstract;
using Cinema.Services.AuthAPI.Infrastructure.Services.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.AuthAPI.Application.Commands.Login
{
    public class LoginRequestHandler(IUserService _userService, IUserRefreshTokenService _userRefreshTokenService, ITokenService _tokenService, AuthUnitOfWork authUnitOfWork) : IRequestHandler<LoginRequest, LoginResponse>
    {
        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _userService.Table
                .Include(u => u.UserRefreshToken)
                .FirstOrDefaultAsync(x => x.UserName.Equals(request.UserName) && x.Password.Equals(request.Password));

            if (user is null)
                throw new Exception("UserName Or Password Is Wrong");

            var response = await _tokenService.CreateTokenAsync(user);

            if(response is null)
                throw new Exception("Beklenmedik bir hatayla karşılaşıldı.");

            if (user.UserRefreshToken == null)
            {
                await _userRefreshTokenService.AddAsync(new()
                {
                    UserId = user.Id,
                    Code = response.RefreshToken,
                    Expiration = response.RefreshTokenExpire,

                });

            }
            else
            {
                user.UserRefreshToken.Code = response.RefreshToken;
                user.UserRefreshToken.Expiration = response.RefreshTokenExpire;
            }

            await authUnitOfWork.SaveChangesAsync();

            return new()
            {
                AccessToken = response.AccessToken,
                RefreshToken = response.RefreshToken,
                RefreshTokenExpire = response.RefreshTokenExpire,
                UserName = response.UserName,
                UserId = user.Id
            };
        }
    }
}
