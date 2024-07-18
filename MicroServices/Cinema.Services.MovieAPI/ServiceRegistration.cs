using Cinema.Services.MovieAPI.Consumers;
using Cinema.Services.MovieAPI.Data.Contexts;
using Cinema.Services.MovieAPI.Services.Abstract;
using Cinema.Services.MovieAPI.Services.Concrete;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Behaviors;
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

            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IMovieImageService, MovieImageService>();
            
        }

        public static void AddMovieMassTransitServices(this IServiceCollection services, string connectionString)
        {
            services.AddMassTransit(configure =>
            {

                configure.AddConsumer<MovieImageUploadedEventConsumer>();
                configure.AddConsumer<MovieImageDeletedEventConsumer>();

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
                });
            });
        }
    }
}
