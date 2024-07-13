using AutoMapper;
using Cinema.Services.RezervationAPI.Models.Dtos;
using Cinema.Services.RezervationAPI.Models.Entities;

namespace Cinema.Services.RezervationAPI.Mapper.RezervationProfile
{
    public class RezervationMapper: Profile
    {
        public RezervationMapper()
        {
            CreateMap<RezervationDto, Rezervation>()
                .ForMember(dest => dest.SeatIds, opt => opt.MapFrom(src => string.Join(",", src.SeatIds)))
                .ReverseMap()
                .ForMember(dest => dest.SeatIds, opt => opt.MapFrom(src => ConvertStringToList(src)));
        }


        private  List<int> ConvertStringToList(Rezervation rezervation)
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
