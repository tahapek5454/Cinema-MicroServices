using Cinema.Services.AiAssistant.Services.Abstract;
using Cinema.Services.AiAssistant.Services.Concrete;
using SharedLibrary.Extensions;

namespace Cinema.Services.AiAssistant
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddAppService(this IServiceCollection services)
        {
            services.AddSingleton<IAiService, AiService>();
            services.AddSingleton<IAppService, AppService>();
            services.AddSharedRepositories();

            return services;
        }
    }
}
