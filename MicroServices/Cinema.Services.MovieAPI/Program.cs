using Cinema.Services.MovieAPI;
using Cinema.Services.MovieAPI.Data.Contexts;
using Cinema.Services.MovieAPI.Extensions;
using Cinema.Services.MovieAPI.Mapper;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.WithOrigins(@"http://localhost:3000", @"https://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
MapFunc.InitializeHttpContextAccessor(builder.Services.BuildServiceProvider());
builder.Services.AddHttpClient();

builder.Services.AddMovieServices(builder.Configuration.GetConnectionString("MSSQL") ?? "");
builder.Services.AddMovieMassTransitServices(builder.Configuration.GetConnectionString("RabbitMQ") ?? "");

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("CorsPolicy");

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseLanguage();

app.UseAuthorization();

app.MapControllers();

ApplyPendigMigration();

app.Run();

void ApplyPendigMigration()
{
    using var scope = app.Services.CreateScope();

    var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (_db.Database.GetPendingMigrations().Count() > 0)
        _db.Database.Migrate();
}