using AutoMapper;
using Cinema.Services.MovieAPI.Application.Dtos.Files;
using Cinema.Services.MovieAPI.Domain.Entities;
using SharedLibrary.Events.MovieImageEvents;
using SharedLibrary.Models.SharedModels.Images;

namespace Cinema.Services.MovieAPI.Application.Mapper.MovieImageProfile
{
    public class MovieImageMapper : Profile
    {
        public MovieImageMapper()
        {
            CreateMap<MovieImageUploadedEvent, MovieImage>()
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.RelationId));

            CreateMap<MovieImage, MovieImageDto>();
            CreateMap<MovieImage, MovieImageSharedVM>();
        }
    }
}
