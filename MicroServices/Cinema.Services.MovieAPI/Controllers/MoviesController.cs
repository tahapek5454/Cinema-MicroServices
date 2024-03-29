﻿using Cinema.Services.MovieAPI.Mapper;
using Cinema.Services.MovieAPI.Models.Dtos.Categories;
using Cinema.Services.MovieAPI.Models.Dtos.Movies;
using Cinema.Services.MovieAPI.Models.Entities;
using Cinema.Services.MovieAPI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Const;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Models.Enums;

namespace Cinema.Services.MovieAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController(IMovieService _movieService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById([FromRoute] int id)
        {
            var movie = await _movieService.Table.Include(x => x.MovieImages).FirstOrDefaultAsync(x => x.Id == id);

            if (movie is null)
                throw new Exception("Movie is not found");

            var movieDto = ObjectMapper.Mapper.Map<MovieDto>(movie);

            var categoryResponse = await _movieService.SendAsync<BlankDto, CategoryDto>(new()
            {
                ActionType = ActionType.GET,
                Language = SystemLanguage.tr_TR,
                Url = $"{SharedConst.CategoryBaseAPI}/GetGategoryById/{movie.CategoryId}",
                Data = null,
                AccessToken = null,
            });

            if (categoryResponse?.ValidateWithData() ?? false)
                movieDto.Category = categoryResponse.Data;
            

            return Ok(ResponseDto<MovieDto>.Sucess(movieDto, 200));
        }

        [HttpGet]
        public async Task<IActionResult> GetMoviesWithPagination([FromQuery] PaginationDto paginationDto)
        {
            var movies = await _movieService.Table
                .Include(x => x.MovieImages)
                .Skip((paginationDto.Page - 1) * paginationDto.Size)
                .Take(paginationDto.Size)
                .ToListAsync();

            var movieDtos = ObjectMapper.Mapper.Map<List<MovieDto>>(movies);

            movieDtos.ForEach(async (movieDto) =>
            {
                var categoryResponse = await _movieService.SendAsync<BlankDto, CategoryDto>(new()
                {
                    ActionType = ActionType.GET,
                    Language = SystemLanguage.tr_TR,
                    Url = $"{SharedConst.CategoryBaseAPI}/GetGategoryById/{movieDto.CategoryId}",
                    Data = null,
                    AccessToken = null,
                });

                if (categoryResponse?.ValidateWithData() ?? false)
                    movieDto.Category = categoryResponse.Data;
            });


            return Ok(ResponseDto<List<MovieDto>>.Sucess(movieDtos, 200));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.Table.Include(x => x.MovieImages).ToListAsync();

            var movieDtos = ObjectMapper.Mapper.Map<List<MovieDto>>(movies);

            movieDtos.ForEach(async (movieDto) =>
            {
                var categoryResponse = await _movieService.SendAsync<BlankDto, CategoryDto>(new()
                {
                    ActionType = ActionType.GET,
                    Language = SystemLanguage.tr_TR,
                    Url = $"{SharedConst.CategoryBaseAPI}/GetGategoryById/{movieDto.CategoryId}",
                    Data = null,
                    AccessToken = null,
                });

                if (categoryResponse?.ValidateWithData() ?? false)
                    movieDto.Category = categoryResponse.Data;
            });


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

        [HttpDelete("{id}")]
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
