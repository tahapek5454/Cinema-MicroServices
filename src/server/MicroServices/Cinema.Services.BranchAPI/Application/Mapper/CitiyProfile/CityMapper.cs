using AutoMapper;
using Cinema.Services.BranchAPI.Application.Commands.Cities.AddCity;
using Cinema.Services.BranchAPI.Application.Dtos;
using Cinema.Services.BranchAPI.Domain.Entities;

namespace Cinema.Services.BranchAPI.Application.Mapper.CitiyProfile
{
    public class CityMapper : Profile
    {
        public CityMapper()
        {
            CreateMap<City, CityDto>()
                .ReverseMap();

            CreateMap<AddCityRequest, City>();
        }
    }
}
