using Microsoft.AspNetCore.Builder;
using SharedLibrary.Middlewares;

namespace SharedLibrary.Extensions
{
    public static class UseLanguageExtension
    {
        public static IApplicationBuilder UseLanguage(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<LanguageMiddleware>();
        }
    }
}
