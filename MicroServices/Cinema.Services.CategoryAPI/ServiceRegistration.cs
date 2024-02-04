using Cinema.Services.CategoryAPI.Data.Contexts;
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
        }
    }
}
