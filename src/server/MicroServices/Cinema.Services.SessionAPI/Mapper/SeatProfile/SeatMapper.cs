using AutoMapper;
using Cinema.Services.SessionAPI.Models.Dtos;
using Cinema.Services.SessionAPI.Models.Entities;

namespace Cinema.Services.SessionAPI.Mapper.SeatProfile
{
    public class SeatMapper: Profile
    {
        public SeatMapper()
        {
            CreateMap<Seat, SeatDto>(); 
        }
    }
}
