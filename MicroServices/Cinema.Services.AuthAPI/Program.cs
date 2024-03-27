using Cinema.Services.AuthAPI;
using Cinema.Services.AuthAPI.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthServices(builder.Configuration.GetConnectionString("MSSQL") ?? string.Empty);

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
