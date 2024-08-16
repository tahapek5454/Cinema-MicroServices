using Cinema.Services.AuthAPI.Application.Services.Abstract;
using Cinema.Services.AuthAPI.Infrastructure.Services.Concrete;
using Cinema.Services.AuthAPI.Persistence.Data.Contexts;
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
