using SharedLibrary.Services;

namespace Cinema.Services.PaymentAPI.Services
{
    public class PaymentServices : BaseService
    {
        public PaymentServices(IHttpClientFactory _httpClientFactory) : base(_httpClientFactory)
        {
        }
    }
}
