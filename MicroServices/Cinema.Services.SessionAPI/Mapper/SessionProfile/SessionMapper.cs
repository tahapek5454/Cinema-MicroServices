using AutoMapper;
using Cinema.Services.SessionAPI.Models.Dtos;
using Cinema.Services.SessionAPI.Models.Entities;

namespace Cinema.Services.SessionAPI.Mapper.SessionProfile
{
    public class SessionMapper: Profile
    {
        public SessionMapper()
        {
            CreateMap<Session, SessionDto>();
        }
    }
}
