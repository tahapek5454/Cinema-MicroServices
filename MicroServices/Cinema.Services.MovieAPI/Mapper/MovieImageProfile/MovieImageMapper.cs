using AutoMapper;
using Cinema.Services.MovieAPI.Models.Entities;
using SharedLibrary.Events.MovieImageEvents;

namespace Cinema.Services.MovieAPI.Mapper.MovieImageProfile
{
    public class MovieImageMapper: Profile
    {
        public MovieImageMapper()
        {
            CreateMap<MovieImageUploadedEvent, MovieImage>()
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.RelationId))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FileId));
        }
    }
}
