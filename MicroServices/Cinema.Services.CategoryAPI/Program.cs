using Cinema.Services.CategoryAPI;
using Cinema.Services.CategoryAPI.Data.Contexts;
using Cinema.Services.CategoryAPI.Extensions;
using Cinema.Services.CategoryAPI.Mapper;
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

builder.Services.AddHttpContextAccessor();
MapFunc.InitializeHttpContextAccessor(builder.Services.BuildServiceProvider());
builder.Services.AddHttpClient();

builder.Services.AddCategoryServices(builder.Configuration.GetConnectionString("MSSQL") ?? string.Empty);

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