﻿using AutoMapper;
using Cinema.Services.BranchAPI.Mapper;
using System.Reflection;

namespace Cinema.Services.BranchAPI.Extensions
{
    public static class MapLanguageExtensions
    {
        public static void MapFromLanguage<TSource, TDestination, TMember>(this IMemberConfigurationExpression<TSource, TDestination, TMember> opt, MemberInfo memberInfo)
        {
            opt.MapFrom((s, d) =>
            {
                return MapFunc.ReturnPropertyLanguageDynamic(s, d, memberInfo);
            });
        }
    }
}
