using Cinema.Services.AuthAPI.Data.Contexts;
using Cinema.Services.AuthAPI.Models.Dtos;
using Cinema.Services.AuthAPI.Models.Entities;
using Cinema.Services.AuthAPI.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Cinema.Services.AuthAPI.Services.Concrete
{
    public class TokenService(AppDbContext _context, IOptions<CustomTokenOptions> _options) : ITokenService
    {
        public async Task<LoginResponse> CreateTokenAsync(User user)
        {
            var accessTokenExpiration = DateTime.UtcNow.AddMinutes(_options.Value.AccessTokenExpiration);
            var securityKey = SignService.GetSymmetricSecurityKey(_options.Value.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
                (issuer: _options.Value.Issuer,
                expires: accessTokenExpiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials,
                claims: await GetClaims(user, _options.Value.Audiences));

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);

            var loginResponseDto = new LoginResponse
            {
                AccessToken = token,
                UserName = user.UserName,
            };

            return loginResponseDto;
        }

        private async Task<IEnumerable<Claim>> GetClaims(User user, string audiences)
        {
            var listedAudiences = audiences.Split(",");

            var userClaimList = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim(ClaimTypes.Name, user.UserName ?? ""),
                new Claim("name", user.Name),
                new Claim("surname", user.Surname),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            userClaimList.AddRange(listedAudiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

            var roleIds = await _context.Users
                .Include(x => x.Roles)
                .Where(x => x.Id.Equals(user.Id))
                .Select(x => x.Roles.Select(y => y.RoleId).ToList()).FirstOrDefaultAsync();

            var roles = await _context.Roles
                .Where(x => (roleIds != null ? roleIds.Contains(x.Id) : false))
                .Select(x => x.Name)
                .ToListAsync();

            userClaimList.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            return userClaimList;
        }
    }
}
