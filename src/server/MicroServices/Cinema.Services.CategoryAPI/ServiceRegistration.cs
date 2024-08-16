using Cinema.Services.CategoryAPI.Application.Services.Abstract;
using Cinema.Services.CategoryAPI.Infrastructure.Services.Concrete;
using Cinema.Services.CategoryAPI.Persistence.Data.Contexts;
using Microsoft.EntityFrameworkCore;

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

            services.AddScoped<ICategoryService, CategoryService>();
        }

      
    }
}
