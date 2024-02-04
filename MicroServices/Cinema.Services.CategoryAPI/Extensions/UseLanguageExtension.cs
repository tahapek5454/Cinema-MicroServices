using Cinema.Services.CategoryAPI.Middlewares;

namespace Cinema.Services.CategoryAPI.Extensions
{
    public static class UseLanguageExtension
    {
        public static IApplicationBuilder UseLanguage(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<LanguageMiddleware>();
        }
    }
}
