using AutoMapper;
using Cinema.Services.BranchAPI.Models.Dtos;
using Cinema.Services.BranchAPI.Models.Entities;
using Cinema.Services.BranchAPI.Models.Requests;

namespace Cinema.Services.BranchAPI.Mapper.CitiyProfile
{
    public class CityMapper: Profile
    {
        public CityMapper()
        {
            CreateMap<City, CityDto>()
                .ReverseMap();

            CreateMap<AddCityRequest, City>();
        }
    }
}
