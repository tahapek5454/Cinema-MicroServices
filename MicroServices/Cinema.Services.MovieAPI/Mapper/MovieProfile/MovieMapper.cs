using AutoMapper;
using Cinema.Services.MovieAPI.Extensions;
using Cinema.Services.MovieAPI.Models.Dtos.Movies;
using Cinema.Services.MovieAPI.Models.Entities;

namespace Cinema.Services.MovieAPI.Mapper.MovieProfile
{
    public class MovieMapper: Profile
    {
        public MovieMapper()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFromLanguage(opt.DestinationMember))
                .ForMember(dest => dest.Description, opt => opt.MapFromLanguage(opt.DestinationMember));

            CreateMap<AddMovieDto, Movie>();

            CreateMap<UpdateMovieDto, Movie>();
        }
    }
}
