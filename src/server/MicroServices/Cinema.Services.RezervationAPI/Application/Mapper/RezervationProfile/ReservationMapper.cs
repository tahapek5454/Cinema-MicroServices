using AutoMapper;
using Cinema.Services.RezervationAPI.Application.Commands.Reservations.CreateReservation;
using Cinema.Services.RezervationAPI.Application.Dtos;
using Cinema.Services.RezervationAPI.Domain.Entities;

namespace Cinema.Services.RezervationAPI.Application.Mapper.RezervationProfile
{
    public class ReservationMapper : Profile
    {
        public ReservationMapper()
        {
            CreateMap<ReservationDto, Reservation>()
                .ForMember(dest => dest.SeatIds, opt => opt.MapFrom(src => string.Join(",", src.SeatIds)))
                .ReverseMap()
                .ForMember(dest => dest.SeatIds, opt => opt.MapFrom(src => ConvertStringToList(src)));


            CreateMap<CreateReservationRequest, Reservation>()
                .ForMember(dest => dest.SeatIds, opt => opt.MapFrom(src => string.Join(",", src.SeatIds)));

        }


        private List<int> ConvertStringToList(Reservation rezervation)
        {
            if (string.IsNullOrEmpty(rezervation.SeatIds))
            {
                return new List<int>();
            }

            return rezervation.SeatIds.Split(',')
                          .Select(int.Parse)
                          .ToList();
        }
    }

}
