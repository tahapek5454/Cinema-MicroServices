using AutoMapper;
using Cinema.Services.BranchAPI.Application.Commands.Branches.AddBranch;
using Cinema.Services.BranchAPI.Application.Dtos;
using Cinema.Services.BranchAPI.Domain.Entities;
using SharedLibrary.Extensions;


namespace Cinema.Services.BranchAPI.Application.Mapper.BranchProfile
{
    public class BranchMapper : Profile
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
