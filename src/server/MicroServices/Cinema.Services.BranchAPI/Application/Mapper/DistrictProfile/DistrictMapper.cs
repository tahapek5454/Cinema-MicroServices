using AutoMapper;
using Cinema.Services.BranchAPI.Application.Commands.Districts.AddDistrict;
using Cinema.Services.BranchAPI.Application.Dtos;
using Cinema.Services.BranchAPI.Domain.Entities;

namespace Cinema.Services.BranchAPI.Application.Mapper.DistrictProfile
{
    public class DistrictMapper : Profile
    {
        public DistrictMapper()
        {
            CreateMap<District, DistrictDto>()
                .ReverseMap();

            CreateMap<AddDistrictRequest, District>();
        }
    }
}
