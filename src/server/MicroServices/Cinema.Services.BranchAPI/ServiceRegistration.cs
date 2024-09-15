using Cinema.Services.BranchAPI.Application.Repositories;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using Cinema.Services.BranchAPI.Infrastructure.Services.Concrete;
using Cinema.Services.BranchAPI.Persistence.Data.Context;
using Cinema.Services.BranchAPI.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Behaviors;
using System.Reflection;

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

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BeforeHandlerBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AfterHandlerBehavior<,>));

            // Repository
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();

            // Service
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<BranchUnitOfWork>();
        }

    }
}
