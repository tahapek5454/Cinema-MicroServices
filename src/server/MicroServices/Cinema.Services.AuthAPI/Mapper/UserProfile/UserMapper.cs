using AutoMapper;
using Cinema.Services.AuthAPI.Models.Dtos;
using Cinema.Services.AuthAPI.Models.Entities;

namespace Cinema.Services.AuthAPI.Mapper.UserProfile
{
    public class UserMapper: Profile
    {
        public UserMapper()
        {
            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<RoleDto, Role>().ReverseMap();

            CreateMap<RegisterRequest, User>();
        }
    }
}
