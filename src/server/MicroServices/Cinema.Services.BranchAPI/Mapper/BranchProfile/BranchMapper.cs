using AutoMapper;
using Cinema.Services.BranchAPI.Models.Dtos;
using Cinema.Services.BranchAPI.Models.Entities;
using Cinema.Services.BranchAPI.Models.Requests;
using SharedLibrary.Extensions;


namespace Cinema.Services.BranchAPI.Mapper.BranchProfile
{
    public class BranchMapper: Profile
    {
        public BranchMapper()
        {
            CreateMap<Branch, BranchDto>()
                .ForMember(dest => dest.Address, opt => opt.MapFromLanguage(opt.DestinationMember))
                .ForMember(dest => dest.Description, opt => opt.MapFromLanguage(opt.DestinationMember));


            CreateMap<AddBranchRequest, Branch>();
        }
    }
}
