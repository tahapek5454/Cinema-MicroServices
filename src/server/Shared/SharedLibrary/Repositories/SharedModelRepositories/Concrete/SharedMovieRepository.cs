using Microsoft.Extensions.Options;
using SharedLibrary.Models.SharedModels.Movies;
using SharedLibrary.Repositories.SharedModelRepositories.Abstract;
using SharedLibrary.Settings;

namespace SharedLibrary.Repositories.SharedModelRepositories.Concrete
{
    public class SharedMovieRepository : SharedBaseRepository<MovieSharedVM>, ISharedMovieRepository
    {
        public SharedMovieRepository(IOptions<MongoDbSettings> options) : base(options)
        {
        }
    }
}
