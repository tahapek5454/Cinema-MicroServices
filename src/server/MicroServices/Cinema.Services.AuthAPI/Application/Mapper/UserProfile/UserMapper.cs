using AutoMapper;
using Cinema.Services.AuthAPI.Application.Dtos;
using Cinema.Services.AuthAPI.Domain.Entities;

namespace Cinema.Services.AuthAPI.Application.Mapper.UserProfile
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<RoleDto, Role>().ReverseMap();

            CreateMap<RegisterRequest, User>();
        }
    }
}
