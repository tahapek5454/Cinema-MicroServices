using Cinema.Services.FileAPI.Application.Repositories;
using Cinema.Services.FileAPI.Application.Services.Abstract;
using Cinema.Services.FileAPI.Infrastructure.Consumer;
using Cinema.Services.FileAPI.Infrastructure.Services.Concrete;
using Cinema.Services.FileAPI.Persistence.Data.Contexts;
using Cinema.Services.FileAPI.Persistence.Repositories;
using Cinema.Services.FileAPI.Storages.Abstract;
using Cinema.Services.FileAPI.Storages.Concrete;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Behaviors;
using SharedLibrary.Settings;
using System.Reflection;

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

            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(BeforeHandlerBehavior<,>));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(AfterHandlerBehavior<,>));

            // Repositories
            serviceCollection.AddScoped<IMovieImageRepository, MovieImageRepository>();

            // Services
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<IMovieImageService, MovieImageService>();
            serviceCollection.AddScoped<FileUnitOfWork>();
        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection)
          where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }


        public static void AddMovieMassTransitServices(this IServiceCollection services, string connectionString)
        {
            services.AddMassTransit(configure =>
            {

                configure.AddConsumer<MovieImageRollbackMessageConsumer>();

                configure.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(connectionString);

                    configurator.ReceiveEndpoint(RabbitMQSettings.File_MovieImageRollbackMessageQueue, e =>
                    {
                        e.ConfigureConsumer<MovieImageRollbackMessageConsumer>(context);
                        e.DiscardSkippedMessages();
                    });
                });
            });
        }

        
    }
}
