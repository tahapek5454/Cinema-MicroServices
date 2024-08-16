using AutoMapper;
using Cinema.Services.SessionAPI.Application.Dtos;
using Cinema.Services.SessionAPI.Domain.Entities;

namespace Cinema.Services.SessionAPI.Application.Mapper.SessionProfile
{
    public class SessionMapper : Profile
    {
        public SessionMapper()
        {
            CreateMap<Session, SessionDto>();
        }
    }
}
