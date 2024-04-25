using Microsoft.EntityFrameworkCore;
using Cinema.Services.SessionAPI.Data.Contexts;

namespace Cinema.Services.SessionAPI
{
    public static class ServiceRegistration
    {
        public static void AddSessionService(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
