using Cinema.Services.CategoryAPI.Application.Repositories;
using Cinema.Services.CategoryAPI.Application.Services.Abstract;
using Cinema.Services.CategoryAPI.Infrastructure.Consumers;
using Cinema.Services.CategoryAPI.Infrastructure.Services.Concrete;
using Cinema.Services.CategoryAPI.Persistence.Data.Contexts;
using Cinema.Services.CategoryAPI.Persistence.Repositories;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Behaviors;
using SharedLibrary.Extensions;
using SharedLibrary.Settings;
using System.Reflection;

namespace Cinema.Services.CategoryAPI
{
    public static class ServiceRegistration
    {
        public static void AddCategoryServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });


            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BeforeHandlerBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AfterHandlerBehavior<,>));


            // Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddSharedRepositories();


            // Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<CategoryUnitOfWork>();
        }

        public static void AddMovieMassTransitServices(this IServiceCollection services, string connectionString)
        {
            services.AddMassTransit(configure =>
            {

      
                configure.AddConsumer<MovieChangeFillCategoryEventConsumer>();

                configure.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(connectionString);

                   

                    configurator.ReceiveEndpoint(RabbitMQSettings.Category_MovieChangeQueue, e =>
                    {
                        e.ConfigureConsumer<MovieChangeFillCategoryEventConsumer>(context);
                        e.DiscardSkippedMessages();
                    });
                });
            });
        }


    }
}
