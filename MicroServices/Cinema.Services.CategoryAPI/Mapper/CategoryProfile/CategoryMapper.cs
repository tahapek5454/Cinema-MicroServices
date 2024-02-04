using AutoMapper;
using Cinema.Services.CategoryAPI.Extensions;
using Cinema.Services.CategoryAPI.Models.Dtos.Categories;
using Cinema.Services.CategoryAPI.Models.Entities;

namespace Cinema.Services.CategoryAPI.Mapper.CategoryProfile
{
    public class CategoryMapper: Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFromLanguage(opt.DestinationMember));

            CreateMap<AddCategoryDto, Category>();

            CreateMap<UpdateCategoryDto, Category>();
        }
    }
}
