using Cinema.Services.BranchAPI;
using Cinema.Services.BranchAPI.Persistence.Data.Context;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Extensions;
using SharedLibrary.Helpers;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwaggerGenService();



builder.Services.AddHttpContextAccessor();
MapFunc.InitializeHttpContextAccessor(builder.Services.BuildServiceProvider());
builder.Services.AddHttpClient();


builder.Services.AddBranchServices(builder.Configuration.GetConnectionString("MSSQL") ?? "");

var app = builder.Build();



app.UseSwagger();
app.UseSwaggerUI();


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