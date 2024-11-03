using AutoMapper;
using Cinema.Services.MovieAPI.Application.Commands.Movies.AddMovie;
using Cinema.Services.MovieAPI.Application.Dtos.Categories;
using Cinema.Services.MovieAPI.Application.Dtos.Comments;
using Cinema.Services.MovieAPI.Application.Dtos.Files;
using Cinema.Services.MovieAPI.Application.Dtos.Movies;
using Cinema.Services.MovieAPI.Domain.Entities;
using SharedLibrary.Extensions;
using SharedLibrary.Models.SharedModels.Categories;
using SharedLibrary.Models.SharedModels.Comments;
using SharedLibrary.Models.SharedModels.Images;
using SharedLibrary.Models.SharedModels.Movies;

namespace Cinema.Services.MovieAPI.Application.Mapper.MovieProfile
{
    public class MovieMapper : Profile
    {
        public MovieMapper()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFromLanguage(opt.DestinationMember))
                .ForMember(dest => dest.Description, opt => opt.MapFromLanguage(opt.DestinationMember));

            CreateMap<Movie, MovieSharedVM>()
                .ForMember(dest => dest.Name, opt => opt.MapFromLanguage(opt.DestinationMember))
                .ForMember(dest => dest.Description, opt => opt.MapFromLanguage(opt.DestinationMember));

            CreateMap<MovieSharedVM, MovieDto>();
            CreateMap<CategorySharedVM, CategoryDto>();
            CreateMap<MovieImageSharedVM, MovieImageDto>();

            CreateMap<MovieComment, MovieCommentDto>();
            CreateMap<MovieCommentSharedVM,  MovieCommentDto>();


            CreateMap<AddMovieRequest, Movie>();
        }
    }
}
