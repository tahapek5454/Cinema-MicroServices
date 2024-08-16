using AutoMapper;
using Cinema.Services.SessionAPI.Application.Dtos;
using Cinema.Services.SessionAPI.Application.Request;
using Cinema.Services.SessionAPI.Domain.Entities;

namespace Cinema.Services.SessionAPI.Application.Mapper.SeatStatusProfile
{
    public class SeatStatusMapper : Profile
    {
        public SeatStatusMapper()
        {
            CreateMap<SeatSessionStatus, SeatSessionStatusDto>()
                .ForMember(dest => dest.SeatNumber, opt => opt.MapFrom(dest => dest.Seat.SeatNumber));


            CreateMap<PreBookingRequest, SeatSessionStatus>();
        }
    }
}
