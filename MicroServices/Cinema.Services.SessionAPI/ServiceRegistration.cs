using Microsoft.EntityFrameworkCore;
using Cinema.Services.SessionAPI.Data.Contexts;
using Cinema.Services.SessionAPI.Services.Abstract;
using Cinema.Services.SessionAPI.Services.Concrete;

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


            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<ISeatStatusService, SeatStatusService>();
            services.AddScoped<ISeatService, SeatService>();
        }
    }
}
