using Cinema.Services.FileAPI.Data.Contexts;
using Cinema.Services.FileAPI.Services.Abstract;
using Cinema.Services.FileAPI.Services.Concrete;
using Cinema.Services.FileAPI.Storages.Abstract;
using Cinema.Services.FileAPI.Storages.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.FileAPI
{
    public static class ServiceRegistration
    {
        public static void AddFileServices(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<IMovieImageService, MovieImageService>();
        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection)
          where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
    }
}
