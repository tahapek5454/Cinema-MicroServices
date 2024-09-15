using AutoMapper;
using Cinema.Services.MovieAPI.Application.Commands.Movies.AddMovie;
using Cinema.Services.MovieAPI.Application.Dtos.Movies;
using Cinema.Services.MovieAPI.Domain.Entities;
using SharedLibrary.Extensions;

namespace Cinema.Services.MovieAPI.Application.Mapper.MovieProfile
{
    public class MovieMapper : Profile
    {
        public MovieMapper()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFromLanguage(opt.DestinationMember))
                .ForMember(dest => dest.Description, opt => opt.MapFromLanguage(opt.DestinationMember));

            CreateMap<AddMovieRequest, Movie>();
        }
    }
}
