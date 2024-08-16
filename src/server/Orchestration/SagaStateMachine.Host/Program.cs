using MassTransit;
using Microsoft.EntityFrameworkCore;
using SagaStateMachine.Host.StateDbContexts;
using SagaStateMachine.Host.StateInstances;
using SagaStateMachine.Host.StateMachines;
using SharedLibrary.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(configure =>
{
    configure.AddSagaStateMachine<MovieImageStateMachine, MovieImageStateInstance>()
    .EntityFrameworkRepository(options =>
    {
        options.AddDbContext<DbContext, MovieAppStateDbContext>((provider, _builder) =>
        {
            _builder.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL"));
        });
    });

    configure.AddSagaStateMachine<ReservationStateMachine, ReservationStateInstance>()
    .EntityFrameworkRepository(options =>
    {
        options.AddDbContext<DbContext, MovieAppStateDbContext>((provider, _builder) =>
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

        configurator.ReceiveEndpoint(RabbitMQSettings.ReservationStateMachineQueue, e =>
        {
            e.ConfigureSaga<ReservationStateInstance>(context);
            e.DiscardSkippedMessages();
        });
    });

});

void ApplyPendigMigration()
{
    var _db = builder.Services.BuildServiceProvider().GetRequiredService<DbContext>();

    if (_db.Database.GetPendingMigrations().Count() > 0)
        _db.Database.Migrate();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

ApplyPendigMigration();

app.Run();
