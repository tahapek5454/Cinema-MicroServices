using Cinema.Services.MovieAPI.Domain.Entities;
using SharedLibrary.Services;

namespace Cinema.Services.MovieAPI.Application.Services.Abstract
{
    public interface IMovieService : IBaseEntityService<Movie>
    {
    }
}
