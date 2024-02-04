using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SharedLibrary.Models.Dtos;
using System.Net;
using System.Net.Mime;

namespace SharedLibrary.Extensions
{
    public static class CustomExceptionHandler
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this WebApplication webApplication)
        {
            webApplication.UseExceptionHandler(configure =>
            {
                configure.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    var errorFeatures = context.Features.Get<IExceptionHandlerFeature>();

                    if (errorFeatures != null)
                    {      
                        var errorDto = new ErrorDto(errorFeatures.Error.Message, true);

                        var responseDto = ResponseDto<BlankDto>.Fail(errorDto, (int)HttpStatusCode.InternalServerError);

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(responseDto));
                    }
                });
            });

            return webApplication;
        }
    }
}
