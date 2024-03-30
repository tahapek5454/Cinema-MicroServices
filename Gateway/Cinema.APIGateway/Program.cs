using Ocelot.DependencyInjection;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Extensions;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.WithOrigins(@"http://localhost:3000", @"https://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

builder.Configuration.AddJsonFile("ocelot.json", false, true);

builder.Services.AddOcelot();

builder.Services.Configure<CustomTokenOptions>(builder.Configuration.GetSection("TokenOptions"));
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<CustomTokenOptions>();
builder.Services.AddCustomTokenAuth(tokenOptions);

var app = builder.Build();

app.UseCors("CorsPolicy");

await app.UseOcelot();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
