using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.Repositories.SharedModelRepositories.Abstract;
using SharedLibrary.Repositories.SharedModelRepositories.Concrete;

namespace SharedLibrary.Extensions
{
    public static class SharedRepositoryExtension
    {
        public static void AddSharedRepositories(this IServiceCollection services)
        {
            services.AddSingleton<ISharedMovieRepository, SharedMovieRepository>();
        }
    }
}
