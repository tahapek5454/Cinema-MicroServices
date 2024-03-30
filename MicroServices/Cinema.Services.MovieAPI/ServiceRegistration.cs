using Cinema.Services.MovieAPI.Consumers;
using Cinema.Services.MovieAPI.Data.Contexts;
using Cinema.Services.MovieAPI.Services.Abstract;
using Cinema.Services.MovieAPI.Services.Concrete;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SharedLibrary.Settings;

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


            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IMovieImageService, MovieImageService>();    
        }

        public static void AddCustomSwaggerGenService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Cinema API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
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
