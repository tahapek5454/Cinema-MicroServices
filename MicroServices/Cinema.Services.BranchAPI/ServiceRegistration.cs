using Cinema.Services.BranchAPI.Data.Context;
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
        }

    }
}
