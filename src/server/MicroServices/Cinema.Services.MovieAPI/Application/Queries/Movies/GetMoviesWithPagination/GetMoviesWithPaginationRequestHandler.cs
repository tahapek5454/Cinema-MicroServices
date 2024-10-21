using Cinema.Services.MovieAPI.Application.Dtos.Movies;
using Cinema.Services.MovieAPI.Application.Mapper;
using MediatR;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Repositories.SharedModelRepositories.Abstract;

namespace Cinema.Services.MovieAPI.Application.Queries.Movies.GetMoviesWithPagination
{
    public class GetMoviesWithPaginationRequestHandler(ISharedMovieRepository _sharedMovieRepository) : IRequestHandler<GetMoviesWithPaginationRequest, GetMoviesWithPaginationResponse>
    {
        public async Task<GetMoviesWithPaginationResponse> Handle(GetMoviesWithPaginationRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _sharedMovieRepository.Get().Count();

            var movies =  _sharedMovieRepository.Get()
                .OrderByDescending(x => x.CreatedDate)
                .Skip((request.Page - 1) * request.Size)
                .Take(request.Size)
                .ToList();

            var movieDtos = ObjectMapper.Mapper.Map<List<MovieDto>>(movies);

            return new()
            {
                Result = ResponseDto<List<MovieDto>>.Sucess(movieDtos, 200),
                TotalCount = totalCount
            };
        }
    }
}
