using Cinema.Services.AuthAPI.Application.Services.Abstract;
using Cinema.Services.AuthAPI.Infrastructure.Services.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.AuthAPI.Application.Commands.RefreshToken
{
    public class RefreshTokenRequestHandler(IUserService _userService, IUserRefreshTokenService _userRefreshTokenService, ITokenService _tokenService, AuthUnitOfWork _authUnitOfWork) : IRequestHandler<RefreshTokenRequest, RefreshTokenResponse>
    {
        public async Task<RefreshTokenResponse> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var refreshToken = await _userRefreshTokenService.Table.FirstOrDefaultAsync(x => x.Code.Equals(request.RefreshToken));

            if (refreshToken == null)
                throw new UnauthorizedAccessException("UnAuthoriize");

            if (refreshToken.Expiration < DateTime.UtcNow)
                throw new UnauthorizedAccessException("Expire");

            var user = await _userService.Table.FirstOrDefaultAsync(x => x.Id.Equals(refreshToken.UserId));

            if (user == null)
                throw new UnauthorizedAccessException("UnAuthoriize");

            var response = await _tokenService.CreateTokenAsync(user);

            // yenilemek yerine refershToken orijinal hali expire olana kadar yararlanılması sağlandı.
            // Eger RefereshTokenın da expire süresi dolarsa login olunmalı
            response.RefreshToken = refreshToken.Code;
            response.RefreshTokenExpire = refreshToken.Expiration;

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
