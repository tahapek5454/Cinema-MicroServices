using Cinema.Services.MovieAPI.Middlewares;

namespace Cinema.Services.MovieAPI.Extensions
{
    public static class UseLanguageExtension
    {
        public static IApplicationBuilder UseLanguage(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<LanguageMiddleware>();
        }
    }
}
