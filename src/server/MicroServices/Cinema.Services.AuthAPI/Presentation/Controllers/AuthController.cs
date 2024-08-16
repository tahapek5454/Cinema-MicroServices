using Cinema.Services.AuthAPI.Application.Dtos;
using Cinema.Services.AuthAPI.Application.Mapper;
using Cinema.Services.AuthAPI.Application.Services.Abstract;
using Cinema.Services.AuthAPI.Domain.Entities;
using Cinema.Services.AuthAPI.Persistence.Data.Contexts;
using Microsoft.AspNetCore.Http;
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
                .FirstOrDefaultAsync(x => x.UserName.Equals(loginRequest.UserName) && x.Password.Equals(loginRequest.Password));

            if (user is null)
                throw new Exception("UserName Or Password Is Wrong");

            var response = await _tokenService.CreateTokenAsync(user);

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
    }
}
