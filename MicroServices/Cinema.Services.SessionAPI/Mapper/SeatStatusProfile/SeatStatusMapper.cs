using AutoMapper;
using Cinema.Services.SessionAPI.Models.Dtos;
using Cinema.Services.SessionAPI.Models.Entities;

namespace Cinema.Services.SessionAPI.Mapper.SeatStatusProfile
{
    public class SeatStatusMapper: Profile
    {
        public SeatStatusMapper()
        {
            CreateMap<SeatSessionStatus, SeatStatusDto>();
        }
    }
}
