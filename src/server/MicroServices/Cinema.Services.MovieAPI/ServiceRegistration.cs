using Cinema.Services.MovieAPI.Application.Repositories;
using Cinema.Services.MovieAPI.Application.Services.Abstract;
using Cinema.Services.MovieAPI.Infrastructure.Consumers;
using Cinema.Services.MovieAPI.Infrastructure.Services.Concrete;
using Cinema.Services.MovieAPI.Persistence.Data.Contexts;
using Cinema.Services.MovieAPI.Persistence.Repositories;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Behaviors;
using SharedLibrary.Extensions;
using SharedLibrary.Settings;
using System.Reflection;

namespace Cinema.Services.MovieAPI
{
    public static class ServiceRegistration
    {
        public static void AddMovieServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BeforeHandlerBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AfterHandlerBehavior<,>));

            // Repositories
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieImageRepository, MovieImageRepository>();
            services.AddSharedRepositories();

            // Services
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IMovieImageService, MovieImageService>();
            services.AddScoped<MovieUnitOfWork>();
            
        }

        public static void AddMovieMassTransitServices(this IServiceCollection services, string connectionString)
        {
            services.AddMassTransit(configure =>
            {

                configure.AddConsumer<MovieImageUploadedEventConsumer>();
                configure.AddConsumer<MovieImageDeletedEventConsumer>();
                configure.AddConsumer<MovieRollBackMessageConsumer>();
                configure.AddConsumer<CategoryChangeFillMovieEventConsumer>();

                configure.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(connectionString);

                    configurator.ReceiveEndpoint(RabbitMQSettings.Movie_MovieImageUploadedQueue, e =>
                    {
                        e.ConfigureConsumer<MovieImageUploadedEventConsumer>(context);
                        e.DiscardSkippedMessages();
                    });

                    configurator.ReceiveEndpoint(RabbitMQSettings.Movie_MovieImageDeletedQueue, e =>
                    {
                        e.ConfigureConsumer<MovieImageDeletedEventConsumer>(context);
                        e.DiscardSkippedMessages();
                    });

                    configurator.ReceiveEndpoint(RabbitMQSettings.Movie_MovieChangeRollBackMessageQueue, e =>
                    {
                        e.ConfigureConsumer<MovieRollBackMessageConsumer>(context);
                        e.DiscardSkippedMessages();
                    });

                    configurator.ReceiveEndpoint(RabbitMQSettings.Movie_CategoryChangeQueue, e =>
                    {
                        e.ConfigureConsumer<CategoryChangeFillMovieEventConsumer>(context);
                        e.DiscardSkippedMessages();
                    });
                });
            });
        }
    }
}
