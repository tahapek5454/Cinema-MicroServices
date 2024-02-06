
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SagaStateMachine.Service.StateDbContexts;
using SagaStateMachine.Service.StateInstances;
using SagaStateMachine.Service.StateMachines;
using SharedLibrary.Settings;
var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMassTransit(configure =>
{
    configure.AddSagaStateMachine<MovieImageStateMachine, MovieImageStateInstance>()
    .EntityFrameworkRepository(options =>
    {
        options.AddDbContext<DbContext, MovieAppStateDbContext>((provider, _builder)=>
        {
            _builder.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL"));
        });
    });

    configure.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host(builder.Configuration.GetConnectionString("RabbitMQ"));

        configurator.ReceiveEndpoint(RabbitMQSettings.FileStateMachineQueue, e =>
        {
            e.ConfigureSaga<MovieImageStateInstance>(context);
            e.DiscardSkippedMessages();
        });
    });

});

var host = builder.Build();
host.Run();
