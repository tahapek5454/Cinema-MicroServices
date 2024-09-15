using Cinema.Services.AuthAPI.Application.Repositories;
using Cinema.Services.AuthAPI.Application.Services.Abstract;
using Cinema.Services.AuthAPI.Infrastructure.Services.Concrete;
using Cinema.Services.AuthAPI.Persistence.Data.Contexts;
using Cinema.Services.AuthAPI.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Behaviors;
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

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BeforeHandlerBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AfterHandlerBehavior<,>));


            // Repo
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRefreshTokenRepository, UserRefreshTokenRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


            // Service
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserRefreshTokenService, UserRefreshTokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<AuthUnitOfWork>();
        }

    }
}
