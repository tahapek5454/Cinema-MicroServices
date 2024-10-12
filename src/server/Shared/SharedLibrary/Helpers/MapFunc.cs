using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.Models.Enums;
using System.Reflection;

namespace SharedLibrary.Helpers
{
    public static class MapFunc
    {
        public static IHttpContextAccessor _accessor { get; private set; }
        public static void InitializeHttpContextAccessor(IServiceProvider serviceProvider)
        {
            _accessor = serviceProvider.GetService<IHttpContextAccessor>();
        }

        public static Func<object, object, MemberInfo, string> ReturnPropertyLanguageDynamic = ReturnPropertyDynamic;
        private static string ReturnPropertyDynamic(object entity, object vm, MemberInfo destinationProperty)
        {
            if (_accessor?.HttpContext?.Items["language"] == null || (SystemLanguage)_accessor.HttpContext.Items["language"] == SystemLanguage.tr_TR)
                return entity.GetType().GetProperty(destinationProperty.Name)?.GetValue(entity)?.ToString() ?? ""; // return default

            string destionationPropertyName = destinationProperty.Name.ToUpper();

            PropertyInfo[] properties = entity.GetType().GetProperties();

            var propertyNames = properties.Select(x => x.Name).ToArray();

            if (!propertyNames.Any())
                return "";

            var sourcePropertyName = propertyNames.FirstOrDefault(x => x.ToUpper() == $"{destionationPropertyName}_EN" || x.ToUpper() == $"{destionationPropertyName}EN");

            if (sourcePropertyName is null)
                return entity.GetType().GetProperty(destinationProperty.Name)?.GetValue(entity)?.ToString() ?? ""; // return default

            PropertyInfo? sourceProperty = entity.GetType().GetProperty(sourcePropertyName);

            if (sourceProperty is null)
                return entity.GetType().GetProperty(destinationProperty.Name)?.GetValue(entity)?.ToString() ?? ""; // return default

            return sourceProperty.GetValue(entity)?.ToString() ?? "";

        }
    }
}
