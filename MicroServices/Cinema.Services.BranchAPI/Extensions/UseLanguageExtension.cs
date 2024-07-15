using Cinema.Services.BranchAPI.Middlewares;

namespace Cinema.Services.BranchAPI.Extensions
{
    public static class UseLanguageExtension
    {
        public static IApplicationBuilder UseLanguage(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<LanguageMiddleware>();
        }
    }
}
