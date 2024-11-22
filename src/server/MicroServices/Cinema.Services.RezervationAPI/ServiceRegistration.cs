using Cinema.Services.RezervationAPI.Application.Repositories;
using Cinema.Services.RezervationAPI.Application.Services.Abstract;
using Cinema.Services.RezervationAPI.Infrastructure.Consumers;
using Cinema.Services.RezervationAPI.Infrastructure.Services.Concrete;
using Cinema.Services.RezervationAPI.Persistence.Data.Contexts;
using Cinema.Services.RezervationAPI.Persistence.Repositories;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Behaviors;
using SharedLibrary.Settings;
using System.Reflection;

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

            services.AddMediatR(configuration => { configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BeforeHandlerBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AfterHandlerBehavior<,>));


            // Repositories
            services.AddScoped<IReservationRepository, ReservationRepository>();

            // Services
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<ReservationUnitOfWork>();

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
