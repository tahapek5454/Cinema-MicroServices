using Cinema.Services.MovieAPI.Application.Dtos.Movies;
using Cinema.Services.MovieAPI.Application.Mapper;
using MediatR;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Repositories.SharedModelRepositories.Abstract;

namespace Cinema.Services.MovieAPI.Application.Queries.Movies.GetMovieById
{
    public class GetMovieByIdRequestHandler : IRequestHandler<GetMovieByIdRequest, GetMovieByIdResponse>
    {
        private readonly ISharedMovieRepository _sharedMovieRepository;

        public GetMovieByIdRequestHandler(ISharedMovieRepository sharedMovieRepository)
        {
            _sharedMovieRepository = sharedMovieRepository;
        }

        public async Task<GetMovieByIdResponse> Handle(GetMovieByIdRequest request, CancellationToken cancellationToken)
        {
            var movie = await _sharedMovieRepository.GetByIdAsync(request.Id);

            if (movie is null)
                throw new Exception("Movie is not found");

            var movieDto = ObjectMapper.Mapper.Map<MovieDto>(movie);

            return new GetMovieByIdResponse()
            {
                Result = ResponseDto<MovieDto>.Sucess(movieDto, 200)
            };

        }
    }
}
