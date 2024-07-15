using Cinema.Services.BranchAPI.Data.Context;
using Cinema.Services.BranchAPI.Services.Abstract;
using Cinema.Services.BranchAPI.Services.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.BranchAPI
{
    public static class ServiceRegistration
    {
        public static void AddBranchServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });


            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IBranchService, BranchService>();
        }

    }
}
