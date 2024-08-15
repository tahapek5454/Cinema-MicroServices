using Cinema.Services.MovieAPI.Application.Dtos.Categories;
using Cinema.Services.MovieAPI.Application.Dtos.Movies;
using Cinema.Services.MovieAPI.Application.Mapper;
using Cinema.Services.MovieAPI.Application.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Const;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Models.Enums;

namespace Cinema.Services.MovieAPI.Application.Queries.GetMovieById
{
    public class GetMovieByIdRequestHandler : IRequestHandler<GetMovieByIdRequest, GetMovieByIdResponse>
    {
        private readonly IMovieService _movieService;

        public GetMovieByIdRequestHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<GetMovieByIdResponse> Handle(GetMovieByIdRequest request, CancellationToken cancellationToken)
        {
            var movie = await _movieService.Table.Include(x => x.MovieImages).FirstOrDefaultAsync(x => x.Id == request.Id);

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


            return new GetMovieByIdResponse()
            {
                Result = ResponseDto<MovieDto>.Sucess(movieDto, 200)
            };

        }
    }
}
