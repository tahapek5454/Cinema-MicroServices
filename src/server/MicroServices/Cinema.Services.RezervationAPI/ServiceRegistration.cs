using Cinema.Services.RezervationAPI.Application.Services.Abstract;
using Cinema.Services.RezervationAPI.Infrastructure.Consumers;
using Cinema.Services.RezervationAPI.Infrastructure.Services.Concrete;
using Cinema.Services.RezervationAPI.Persistence.Data.Contexts;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Settings;

namespace Cinema.Services.SessionAPI
{
    public static class ServiceRegistration
    {
        public static void AddReservationService(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IReservationService, ReservationService>();

        }


        public static void AddReservationMassTransitServices(this IServiceCollection services, string connectionString)
        {
            services.AddMassTransit(configure =>
            {

                configure.AddConsumer<ReservationRollbackConsumer>();


                configure.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(connectionString);

                    configurator.ReceiveEndpoint(RabbitMQSettings.Reservation_ReservationRollbackMessageQueue, e =>
                    {
                        e.ConfigureConsumer<ReservationRollbackConsumer>(context);
                        e.DiscardSkippedMessages();
                    });
                });
            });
        }
    }
}
