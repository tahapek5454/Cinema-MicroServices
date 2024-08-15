using Cinema.Services.BranchAPI;
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

app.Run();
