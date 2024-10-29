using Cinema.Services.MovieAPI.Application.Dtos.Movies;
using Cinema.Services.MovieAPI.Application.Mapper;
using MediatR;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Repositories.SharedModelRepositories.Abstract;

namespace Cinema.Services.MovieAPI.Application.Queries.Movies.GetAllMovies
{
    public class GetAllMoviesRequestHandler(ISharedMovieRepository _sharedMovieRepository) : IRequestHandler<GetAllMoviesRequest, GetAllMoviesResponse>
    {
        public async Task<GetAllMoviesResponse> Handle(GetAllMoviesRequest request, CancellationToken cancellationToken)
        {
            var movies =  _sharedMovieRepository.Get().OrderByDescending(x => x.CreatedDate).ToList();

            var movieDtos = ObjectMapper.Mapper.Map<List<MovieDto>>(movies);
            
            return new()
            {
                Result = ResponseDto<List<MovieDto>>.Sucess(movieDtos, 200)
            };
        }
    }
}
