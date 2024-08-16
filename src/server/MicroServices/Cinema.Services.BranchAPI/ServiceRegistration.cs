using Cinema.Services.BranchAPI.Application.Services.Abstract;
using Cinema.Services.BranchAPI.Infrastructure.Services.Concrete;
using Cinema.Services.BranchAPI.Persistence.Data.Context;
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
