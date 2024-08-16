using AutoMapper;
using Cinema.Services.SessionAPI.Application.Dtos;
using Cinema.Services.SessionAPI.Domain.Entities;

namespace Cinema.Services.SessionAPI.Application.Mapper.SeatProfile
{
    public class SeatMapper : Profile
    {
        public SeatMapper()
        {
            CreateMap<Seat, SeatDto>();
        }
    }
}
