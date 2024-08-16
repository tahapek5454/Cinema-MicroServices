using Microsoft.EntityFrameworkCore;
using MassTransit;
using SharedLibrary.Settings;
using Cinema.Services.SessionAPI.Infrastructure.Consumers;
using Cinema.Services.SessionAPI.Infrastructure.Services.Concrete;
using Cinema.Services.SessionAPI.Persistence.Data.Contexts;
using Cinema.Services.SessionAPI.Application.Services.Abstract;

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


            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<ISeatSessionStatusService, SeatSessionStatusService>();
            services.AddScoped<ISeatService, SeatService>();
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
