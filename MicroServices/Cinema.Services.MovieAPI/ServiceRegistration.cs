using Cinema.Services.MovieAPI.Data.Contexts;
using Cinema.Services.MovieAPI.Services.Abstract;
using Cinema.Services.MovieAPI.Services.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.MovieAPI
{
    public static class ServiceRegistration
    {
        public static void AddMovieServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });


            services.AddScoped<IMovieService, MovieService>();
        }
    }
}
