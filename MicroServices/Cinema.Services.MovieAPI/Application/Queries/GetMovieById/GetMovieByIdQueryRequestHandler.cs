using Cinema.Services.MovieAPI.Mapper;
using Cinema.Services.MovieAPI.Models.Dtos.Categories;
using Cinema.Services.MovieAPI.Models.Dtos.Movies;
using Cinema.Services.MovieAPI.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Const;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Models.Enums;

namespace Cinema.Services.MovieAPI.Application.Queries.GetMovieById
{
    public class GetMovieByIdQueryRequestHandler : IRequestHandler<GetMovieByIdQueryRequest, GetMovieByIdQueryResponse>
    {
        private readonly IMovieService _movieService;

        public GetMovieByIdQueryRequestHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<GetMovieByIdQueryResponse> Handle(GetMovieByIdQueryRequest request, CancellationToken cancellationToken)
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


            return new GetMovieByIdQueryResponse()
            {
                Response = ResponseDto<MovieDto>.Sucess(movieDto, 200)
            };

        }
    }
}
