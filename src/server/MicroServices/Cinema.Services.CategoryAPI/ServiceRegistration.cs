using Cinema.Services.CategoryAPI.Application.Repositories;
using Cinema.Services.CategoryAPI.Application.Services.Abstract;
using Cinema.Services.CategoryAPI.Infrastructure.Services.Concrete;
using Cinema.Services.CategoryAPI.Persistence.Data.Contexts;
using Cinema.Services.CategoryAPI.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Behaviors;
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


            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BeforeHandlerBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AfterHandlerBehavior<,>));


            // Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            // Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<CategoryUnitOfWork>();
        }

      
    }
}
