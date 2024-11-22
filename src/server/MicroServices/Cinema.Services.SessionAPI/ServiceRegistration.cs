using Microsoft.EntityFrameworkCore;
using MassTransit;
using SharedLibrary.Settings;
using Cinema.Services.SessionAPI.Infrastructure.Consumers;
using Cinema.Services.SessionAPI.Infrastructure.Services.Concrete;
using Cinema.Services.SessionAPI.Persistence.Data.Contexts;
using Cinema.Services.SessionAPI.Application.Services.Abstract;
using Cinema.Services.SessionAPI.Application.Repositories;
using Cinema.Services.SessionAPI.Persistence.Repositories;
using MediatR;
using SharedLibrary.Behaviors;
using System.Reflection;
using Cinema.Services.SessionAPI.Application.Services.Abstract.HubServices;
using Cinema.Services.SessionAPI.Infrastructure.Services.Concrete.HubServices;

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



            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BeforeHandlerBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AfterHandlerBehavior<,>));

            // Repositories
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<IMovieTheaterRepository, MovieTheaterRepository>();
            services.AddScoped<ISeatSessionStatusRepository, SeatSessionStatusRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();



            // Services
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<ISeatSessionStatusService, SeatSessionStatusService>();
            services.AddScoped<ISeatService, SeatService>();
            services.AddScoped<IMovieTheaterService, MovieTheaterService>();
            services.AddScoped<SessionUnitOfWork>();
            services.AddScoped<ISeatStatusHubService, SeatStatusHubService>();

        }


        public static void AddSessionMassTransitServices(this IServiceCollection services, string connectionString)
        {
            services.AddMassTransit(configure =>
            {

                configure.AddConsumer<ReservedEventConsumer>();


                configure.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(connectionString);

                    configurator.ReceiveEndpoint(RabbitMQSettings.Session_ReservedQueue, e =>
                    {
                        e.ConfigureConsumer<ReservedEventConsumer>(context);
                        e.DiscardSkippedMessages();
                    });
                });
            });
        }
    }
}
