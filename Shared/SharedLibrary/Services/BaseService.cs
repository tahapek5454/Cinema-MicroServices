using Newtonsoft.Json;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Models.Enums;
using System.Net.Mime;
using System.Text;

namespace SharedLibrary.Services
{
    public class BaseService(IHttpClientFactory _httpClientFactory) : IBaseService
    {
        public async Task<ResponseDto<TResponse>> SendAsync<TRequest, TResponse>(RequestDto<TRequest> requestDto, bool isAuthorize = true)
            where TRequest : class
            where TResponse : class
        {

            try
            {
                HttpClient client = _httpClientFactory.CreateClient();
                HttpRequestMessage message = new();

                // language support
                if (requestDto.Language.Equals(SystemLanguage.en_EN))
                    message.Headers.Add("support_language", SystemLanguage.en_EN.ToString());
                else
                    message.Headers.Add("support_language", SystemLanguage.tr_TR.ToString());

                // token operations
                if (isAuthorize)
                {
                    var token = requestDto.AccessToken is not null ? requestDto.AccessToken : string.Empty;

                    message.Headers.Add("Authorization", $"Bearer {token}");
                }

                message.RequestUri = new Uri(requestDto.Url);

                if (requestDto.Data is not null)
                {
                    message.Content =
                        new StringContent
                        (JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, MediaTypeNames.Application.Json);
                }
                HttpResponseMessage? apiResponse = null;

                message.Method = requestDto.ActionType switch
                {
                    ActionType.POST => HttpMethod.Post,
                    ActionType.PUT => HttpMethod.Put,
                    ActionType.DELETE => HttpMethod.Delete,
                    _ => HttpMethod.Get
                };

                apiResponse = await client.SendAsync(message);

                ResponseDto<TResponse>? result = apiResponse.StatusCode switch
                {
                    System.Net.HttpStatusCode.NotFound => ResponseDto<TResponse>.Fail("Not Found", true, 404),
                    System.Net.HttpStatusCode.Forbidden => ResponseDto<TResponse>.Fail("Forbidden", true, 403),
                    System.Net.HttpStatusCode.Unauthorized => ResponseDto<TResponse>.Fail("Unauthorized", true, 401),
                    System.Net.HttpStatusCode.InternalServerError => ResponseDto<TResponse>.Fail("Internal Server Error", true, 500),
                    _ => null
                };

                if (result is null)
                    result = JsonConvert.DeserializeObject<ResponseDto<TResponse>>(await apiResponse.Content.ReadAsStringAsync());


                return result ?? ResponseDto<TResponse>.Fail("Deserialize failed", false, 500);

            }
            catch (Exception e)
            {
                // TODO: log erro to elastic search

                return ResponseDto<TResponse>.Fail($"Http request failed + {e.Message}", false, 500);
            }
        }

        public int AdvancedUpdate<TModel, TRequest>(TModel model, TRequest request)
            where TModel : class
            where TRequest : class
        {
            var entityType = typeof(TModel);
            var requestType = typeof(TRequest);

            var entityProperties = entityType.GetProperties();
            var requestProperties = requestType.GetProperties();

            var pk = entityType.GetProperty("Id"); // we use primary key like Id if you change pk name you have to change this

            var updatedPropertyCount = 0;

            // request and entity properties have to same
            foreach (var requestProperty in requestProperties)
            {
                var entityProperty = entityProperties.FirstOrDefault(p => p.Name == requestProperty.Name);
                var updatedValue = requestProperty.GetValue(request);

                if (entityProperty != null && updatedValue != null && requestProperty != pk)
                {
                    entityProperty.SetValue(model, updatedValue);
                    updatedPropertyCount++;
                }
            }

            return updatedPropertyCount;
        }
    }
}
