using Cinema.Services.MovieAPI.Application.Dtos.Categories;
using Cinema.Services.MovieAPI.Application.Dtos.Movies;
using Cinema.Services.MovieAPI.Application.Mapper;
using Cinema.Services.MovieAPI.Application.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Const;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Models.Enums;

namespace Cinema.Services.MovieAPI.Application.Queries.Movies.GetMoviesWithPagination
{
    public class GetMoviesWithPaginationRequestHandler(IMovieService _movieService) : IRequestHandler<GetMoviesWithPaginationRequest, GetMoviesWithPaginationResponse>
    {
        public async Task<GetMoviesWithPaginationResponse> Handle(GetMoviesWithPaginationRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _movieService.Table.Count();

            var movies = await _movieService.Table
            .Include(x => x.MovieImages)
                .Skip((request.Page - 1) * request.Size)
                .Take(request.Size)
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

                if (categoryResponse.ValidateWithData())
                    movieDto.Category = categoryResponse?.Data ?? new();
            });


            return new()
            {
                Result = ResponseDto<List<MovieDto>>.Sucess(movieDtos, 200),
                TotalCount = totalCount
            };
        }
    }
}
