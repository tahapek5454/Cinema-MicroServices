using Cinema.Services.AuthAPI.Data.Contexts;
using Cinema.Services.AuthAPI.Services.Abstract;
using Cinema.Services.AuthAPI.Services.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ITokenService, TokenService>();
        }

    }
}
