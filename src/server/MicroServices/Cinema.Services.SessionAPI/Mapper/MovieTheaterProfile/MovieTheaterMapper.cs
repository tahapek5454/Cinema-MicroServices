using AutoMapper;
using Cinema.Services.SessionAPI.Models.Dtos;
using Cinema.Services.SessionAPI.Models.Entities;

namespace Cinema.Services.SessionAPI.Mapper.MovieTheaterProfile
{
    public class MovieTheaterMapper: Profile
    {
        public MovieTheaterMapper()
        {
            CreateMap<MovieTheater, MovieTheaterDto>();
        }
    }
}
