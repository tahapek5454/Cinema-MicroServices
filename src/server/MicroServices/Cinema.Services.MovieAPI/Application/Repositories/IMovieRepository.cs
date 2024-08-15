using Cinema.Services.MovieAPI.Domain.Entities;
using SharedLibrary.Repositories;

namespace Cinema.Services.MovieAPI.Application.Repositories
{
    public interface IMovieRepository: IBaseRepository<Movie>
    {
    }
}
