using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Cinema.Services.PaymentAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        


        [HttpPost]
        public ActionResult PayProduct ([FromBody]Body requestBody)
        {
            /**
              Burada siparişin kontolleri vs yapıyorum..
            **/

            Options options = new Options();
            options.ApiKey = "sandbox-c3rnCqKPHKelPshxPkt7mmUhYg74QOqd";
            options.SecretKey = "sandbox-z8MqdFiOBeg26EmqnYearwPua4wAioyq";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = "123456789";
            request.Price = "1";
            request.PaidPrice = "1.2";
            request.Currency = Currency.TRY.ToString();
            request.BasketId = "B67832";
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
            request.CallbackUrl = "https://domain.com/payment/callback/" + "123456789";

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = "John";
            buyer.Surname = "Doe";
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            request.BillingAddress = new Address
            {
                ContactName = "Gizem" + " " + "Kaya",
                City = "Istanbul",
                Country = "Türkiye",
                Description = "Maslak"
            };

            // Ben her siparişte tek bir olacak şekilde ayarladığım için sepette tek ürün var o da siparişin kendisi.
            var basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem();
            firstBasketItem.Id = "BI101";
            firstBasketItem.Name = "Binocular";
            firstBasketItem.Category1 = "Collectibles";
            firstBasketItem.Category2 = "Accessories";
            firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            firstBasketItem.Price = "1";
            basketItems.Add(firstBasketItem);
            request.BasketItems = basketItems;



            var checkoutFormInitialize = CheckoutFormInitialize.Create(request, options);

            return Content(checkoutFormInitialize.CheckoutFormContent, "text/javascript");
        }

    }

    public class Body
    {
        public string Name { get; set; }
    }
}
