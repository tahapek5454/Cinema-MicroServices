using Cinema.Services.FileAPI.Consumer;
using Cinema.Services.FileAPI.Data.Contexts;
using Cinema.Services.FileAPI.Services.Abstract;
using Cinema.Services.FileAPI.Services.Concrete;
using Cinema.Services.FileAPI.Storages.Abstract;
using Cinema.Services.FileAPI.Storages.Concrete;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SharedLibrary.Settings;

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
    }
}
