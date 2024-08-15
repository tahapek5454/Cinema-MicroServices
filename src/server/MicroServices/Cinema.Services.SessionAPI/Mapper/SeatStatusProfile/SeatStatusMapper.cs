using AutoMapper;
using Cinema.Services.SessionAPI.Models.Dtos;
using Cinema.Services.SessionAPI.Models.Entities;
using Cinema.Services.SessionAPI.Models.Request;

namespace Cinema.Services.SessionAPI.Mapper.SeatStatusProfile
{
    public class SeatStatusMapper: Profile
    {
        public SeatStatusMapper()
        {
            CreateMap<SeatSessionStatus, SeatSessionStatusDto>()
                .ForMember(dest => dest.SeatNumber, opt => opt.MapFrom(dest => dest.Seat.SeatNumber));


            CreateMap<PreBookingRequest, SeatSessionStatus>();
        }
    }
}
