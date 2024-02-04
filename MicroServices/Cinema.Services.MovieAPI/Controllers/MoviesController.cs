using Cinema.Services.MovieAPI.Mapper;
using Cinema.Services.MovieAPI.Models.Dtos.Movies;
using Cinema.Services.MovieAPI.Models.Entities;
using Cinema.Services.MovieAPI.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Dtos;

namespace Cinema.Services.MovieAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController(IMovieService _movieService) : ControllerBase
    {
        [HttpGet("id")]
        public async Task<IActionResult> GetMovieById([FromRoute] int id)
        {
            var movie = await _movieService.Table.FirstOrDefaultAsync(x => x.Id == id);

            if (movie is null)
                throw new Exception("Movie is not found");

            var movieDto = ObjectMapper.Mapper.Map<MovieDto>(movie);

            // fetch movie category and files

            return Ok(ResponseDto<MovieDto>.Sucess(movieDto, 200));
        }

        [HttpGet]
        public async Task<IActionResult> GetMoviesWithPagination([FromQuery] PaginationDto paginationDto)
        {
            var movies = await _movieService.Table
                .Skip((paginationDto.Page - 1) * paginationDto.Size)
                .Take(paginationDto.Size)
                .ToListAsync();

            var movieDtos = ObjectMapper.Mapper.Map<List<MovieDto>>(movies);

            // fetch movie category and files

            return Ok(ResponseDto<List<MovieDto>>.Sucess(movieDtos, 200));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies([FromQuery] PaginationDto paginationDto)
        {
            var movies = await _movieService.Table.ToListAsync();

            var movieDtos = ObjectMapper.Mapper.Map<List<MovieDto>>(movies);

            // fetch movie category and files

            return Ok(ResponseDto<List<MovieDto>>.Sucess(movieDtos, 200));
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] AddMovieDto addMovieDto)
        {
            var newMovie = ObjectMapper.Mapper.Map<Movie>(addMovieDto);

            await _movieService.Table.AddAsync(newMovie);

            await _movieService.SaveChangesAsync();

            return Created($"GetMovieById/{newMovie.Id}", ResponseDto<BlankDto>.Sucess(200));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie([FromBody]  UpdateMovieDto updateMovieDto)
        {
            var newMovie = ObjectMapper.Mapper.Map<Movie>(updateMovieDto);

            _movieService.Table.Update(newMovie);

            await _movieService.SaveChangesAsync();

            return Ok(ResponseDto<BlankDto>.Sucess(200));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> RemoveMovie([FromRoute] int id)
        {
            var movie = await _movieService.Table.FirstOrDefaultAsync(x => x.Id == id);

            if (movie is null)
                throw new Exception("Movie is not found");

            _movieService.Table.Remove(movie);

            await _movieService.SaveChangesAsync();

            return Ok(ResponseDto<BlankDto>.Sucess(200));
        }
    }
}
