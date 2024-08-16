using AutoMapper;
using Cinema.Services.SessionAPI.Application.Dtos;
using Cinema.Services.SessionAPI.Domain.Entities;

namespace Cinema.Services.SessionAPI.Application.Mapper.MovieTheaterProfile
{
    public class MovieTheaterMapper : Profile
    {
        public MovieTheaterMapper()
        {
            CreateMap<MovieTheater, MovieTheaterDto>();
        }
    }
}
