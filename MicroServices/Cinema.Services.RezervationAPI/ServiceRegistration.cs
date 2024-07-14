using Cinema.Services.RezervationAPI.Data.Contexts;
using Cinema.Services.RezervationAPI.Service.Abstract;
using Cinema.Services.RezervationAPI.Service.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.SessionAPI
{
    public static class ServiceRegistration
    {
        public static void AddReservationService(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IReservationService, ReservationService>();

        }
    }
}
