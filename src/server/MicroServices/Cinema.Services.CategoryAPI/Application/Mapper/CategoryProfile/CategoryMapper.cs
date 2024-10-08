﻿using AutoMapper;
using Cinema.Services.CategoryAPI.Application.Commands.Categories.AddGategory;
using Cinema.Services.CategoryAPI.Application.Commands.Categories.UpdateGategory;
using Cinema.Services.CategoryAPI.Application.Dtos.Categories;
using Cinema.Services.CategoryAPI.Domain.Entities;
using SharedLibrary.Extensions;

namespace Cinema.Services.CategoryAPI.Application.Mapper.CategoryProfile
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFromLanguage(opt.DestinationMember));

            CreateMap<AddCategoryRequest, Category>();

            CreateMap<UpdateGategoryRequest, Category>();
        }
    }
}
