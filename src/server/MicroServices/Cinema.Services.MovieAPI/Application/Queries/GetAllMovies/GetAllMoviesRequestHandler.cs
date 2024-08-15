using Cinema.Services.MovieAPI.Mapper;
using Cinema.Services.MovieAPI.Models.Dtos.Categories;
using Cinema.Services.MovieAPI.Models.Dtos.Movies;
using Cinema.Services.MovieAPI.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Const;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Models.Enums;

namespace Cinema.Services.MovieAPI.Application.Queries.GetAllMovies
{
    public class GetAllMoviesRequestHandler(IMovieService _movieService) : IRequestHandler<GetAllMoviesRequest, GetAllMoviesResponse>
    {
        public async Task<GetAllMoviesResponse> Handle(GetAllMoviesRequest request, CancellationToken cancellationToken)
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

                if (categoryResponse.ValidateWithData())
                    movieDto.Category = categoryResponse?.Data ?? new();
            });


            return new()
            {
                Result = ResponseDto<List<MovieDto>>.Sucess(movieDtos, 200)
            };
        }
    }
}
