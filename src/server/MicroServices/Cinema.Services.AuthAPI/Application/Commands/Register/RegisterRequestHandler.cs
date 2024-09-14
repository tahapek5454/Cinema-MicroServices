using Cinema.Services.AuthAPI.Application.Mapper;
using Cinema.Services.AuthAPI.Application.Services.Abstract;
using Cinema.Services.AuthAPI.Domain.Entities;
using Cinema.Services.AuthAPI.Infrastructure.Services.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.AuthAPI.Application.Commands.Register
{
    public class RegisterRequestHandler(IUserService _userService, AuthUnitOfWork _authUnitOfWork) : IRequestHandler<RegisterRequest, RegisterResponse>
    {
        public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var isExist = await _userService.Table.AnyAsync(x => x.UserName.Equals(request.UserName));

            if (isExist)
                throw new Exception("This UserName Already Registered");

            var user = ObjectMapper.Mapper.Map<User>(request);

            user.Roles ??= new List<UserRole>()
            {
                new()
                {
                    RoleId = 2
                }
            };

            await _userService.AddAsync(user);
            await _authUnitOfWork.SaveChangesAsync();

            return new();
        }
    }
}
