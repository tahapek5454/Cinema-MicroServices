using Cinema.Services.AuthAPI.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.AuthAPI
{
    public static class ServiceRegistration
    {
        public static void AddAuthServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
