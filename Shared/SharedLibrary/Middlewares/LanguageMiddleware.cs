﻿using Microsoft.AspNetCore.Http;
using SharedLibrary.Models.Enums;

namespace SharedLibrary.Middlewares
{
    public class LanguageMiddleware
    {
        private readonly RequestDelegate _next;
        public LanguageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var headerDict = context.Request.Headers;

            SystemLanguage systemLanguage;

            bool isSuccess = Enum.TryParse<SystemLanguage>(headerDict["support_language"].ToString() ?? SystemLanguage.tr_TR.ToString(), out systemLanguage);

            if (isSuccess)
                context.Items.Add("language", systemLanguage);
            else
                context.Items.Add("language", SystemLanguage.tr_TR);

            await _next(context);
        }
    }
}
