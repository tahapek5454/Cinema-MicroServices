using Cinema.Services.SessionAPI.Application.Repositories;
using Cinema.Services.SessionAPI.Application.Services.Abstract;
using Cinema.Services.SessionAPI.Domain.Entities;
using SharedLibrary.Services;

namespace Cinema.Services.SessionAPI.Infrastructure.Services.Concrete
{
    public class MovieTheaterService : BaseEntityService<MovieTheater>, IMovieTheaterService
    {
        public MovieTheaterService(IHttpClientFactory _httpClientFactory, IMovieTheaterRepository repository) : base(_httpClientFactory, repository)
        {
        }
    }
}
