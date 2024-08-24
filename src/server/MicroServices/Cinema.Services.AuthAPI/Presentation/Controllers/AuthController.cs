using Cinema.Services.AuthAPI.Application.Dtos;
using Cinema.Services.AuthAPI.Application.Mapper;
using Cinema.Services.AuthAPI.Application.Services.Abstract;
using Cinema.Services.AuthAPI.Domain.Entities;
using Cinema.Services.AuthAPI.Persistence.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Dtos;

namespace Cinema.Services.AuthAPI.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(AppDbContext _context, ITokenService _tokenService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var user = await _context.Users
                .Include(u => u.UserRefreshToken)
                .FirstOrDefaultAsync(x => x.UserName.Equals(loginRequest.UserName) && x.Password.Equals(loginRequest.Password));

            if (user is null)
                throw new Exception("UserName Or Password Is Wrong");

            var response = await _tokenService.CreateTokenAsync(user);

            if(user.UserRefreshToken == null)
            {
                await _context.UserRefreshTokens.AddAsync(new()
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

            await _context.SaveChangesAsync();

            return Ok(ResponseDto<LoginResponse>.Sucess(response, 200));
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            var isExist = await _context.Users.AnyAsync(x => x.UserName.Equals(registerRequest.UserName));

            if (isExist)
                throw new Exception("This UserName Already Registered");

            var user = ObjectMapper.Mapper.Map<User>(registerRequest);

            user.Roles ??= new List<UserRole>()
            {
                new()
                {
                    RoleId = 2
                }
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Created();

        }

        [HttpGet]
        public async Task<IActionResult> GetSelam()
        {
            return Ok("Selam");
        }



        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var refreshToken = await _context.UserRefreshTokens.FirstOrDefaultAsync(x => x.Code.Equals(request.RefreshToken));

            if (refreshToken == null)
                throw new UnauthorizedAccessException("UnAuthoriize");

            if (refreshToken.Expiration < DateTime.UtcNow)
                throw new Exception("Expire");

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(refreshToken.UserId));

            if(user == null)
                throw new UnauthorizedAccessException("UnAuthoriize");

            var response = await _tokenService.CreateTokenAsync(user);

            refreshToken.Code = response.RefreshToken;
            refreshToken.Expiration = response.RefreshTokenExpire;

            await _context.SaveChangesAsync();  

            return Ok(ResponseDto<LoginResponse>.Sucess(response, 200));
        }
    }
}
