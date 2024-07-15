using AutoMapper;
using Cinema.Services.BranchAPI.Models.Dtos;
using Cinema.Services.BranchAPI.Models.Entities;

namespace Cinema.Services.BranchAPI.Mapper.DistrictProfile
{
    public class DistrictMapper: Profile
    {
        public DistrictMapper()
        {
            CreateMap<District, DistrictDto>()
                .ReverseMap();
        }
    }
}
