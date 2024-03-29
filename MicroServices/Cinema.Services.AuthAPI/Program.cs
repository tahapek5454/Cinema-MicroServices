using Cinema.Services.AuthAPI;
using Cinema.Services.AuthAPI.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Extensions;
using SharedLibrary.Models.Dtos;

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
builder.Services.AddCustomSwaggerGenService();

builder.Services.Configure<CustomTokenOptions>(builder.Configuration.GetSection("TokenOptions"));

builder.Services.AddAuthServices(builder.Configuration.GetConnectionString("MSSQL") ?? string.Empty);

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<CustomTokenOptions>();
builder.Services.AddCustomTokenAuth(tokenOptions);

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("CorsPolicy");

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

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
