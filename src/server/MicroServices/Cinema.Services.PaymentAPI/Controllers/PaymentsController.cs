﻿using Cinema.Services.PaymentAPI.Services;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models.Dtos;
using System.Web;

namespace Cinema.Services.PaymentAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentsController(PaymentServices _paymentServices) : ControllerBase
    {
        


        [HttpPost]
        public async Task<ActionResult> PayProductAsync ([FromBody]Body requestBody)
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
            request.PaidPrice = "100";
            request.Currency = Currency.TRY.ToString();
            request.BasketId = "B67832";
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
            request.CallbackUrl = BuildCallbackUrl(requestBody);

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

        [HttpPost]
        public IActionResult PaymentCallback(
            [FromQuery] string sessionId,
            [FromQuery] string userId,
            [FromQuery] string seatIds)
        {
            var seatIdsList = seatIds.ToString().Split(',').Select(int.Parse).ToList();

            var body = new Body
            {
                SessionId = int.Parse(sessionId),
                UserId = int.Parse(userId),
                SeatIds = seatIdsList
            };

            try
            {
                // Send data to the reservation server
                 _paymentServices.SendAsync<Body, BlankDto>(new()
                {
                    AccessToken = null,
                    ActionType = SharedLibrary.Models.Enums.ActionType.POST,
                    Data = body,
                    Language = SharedLibrary.Models.Enums.SystemLanguage.tr_TR,
                    Url = "http://gateway-svc:8080/reservationserver/public/api/Reservations/CreateReservation"
                 });
            }
            catch (Exception e)
            {
                var a = e;
                throw;
            }

            return Content(@"
                        <html>
                            <head>
                                <title>Ödeme Sonucu</title>
                                <style>
                                    body {
                                        font-family: Arial, sans-serif;
                                        text-align: center;
                                        margin-top: 50px;
                                    }
                                    .message-box {
                                        padding: 20px;
                                        background-color: #dff0d8;
                                        border: 1px solid #d0e9c6;
                                        color: #3c763d;
                                        border-radius: 5px;
                                        font-size: 18px;
                                        display: inline-block;
                                        margin-bottom: 20px;
                                    }
                                    .button {
                                        padding: 10px 20px;
                                        background-color: #5bc0de;
                                        border: none;
                                        color: white;
                                        font-size: 16px;
                                        cursor: pointer;
                                        border-radius: 5px;
                                        margin-top: 20px;
                                    }
                                    .button:hover {
                                        background-color: #31b0d5;
                                    }
                                </style>
                            </head>
                            <body>
                                <div class='message-box'>
                                    Odeme basariyla tamamlandi! Tesekkur ederiz.
                                </div>
                                </br>
                                <div>
                                   <button class='button' onclick='redirectToTicketBuy()'>Siteye donmek icin tiklayiniz</button>
                                </div>

                                <script>
                                    function redirectToTicketBuy() {
                                        window.location.href = 'http://web-svc:80/';
                                    }
                                </script>
                            </body>
                        </html>
                    ", "text/html");

        }
        private string BuildCallbackUrl(Body requestBody)
        {
            var uriBuilder = new UriBuilder("http://gateway-svc:8080/paymentserver/public/api/Payments/PaymentCallback");

            var queryParams = HttpUtility.ParseQueryString(uriBuilder.Query);
            queryParams["SessionId"] = requestBody.SessionId.ToString();
            queryParams["UserId"] = requestBody.UserId.ToString();
            queryParams["SeatIds"] = string.Join(",", requestBody.SeatIds);

            uriBuilder.Query = queryParams.ToString();

            return uriBuilder.ToString();
        }

    }

    public class Body
    {
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public List<int> SeatIds { get; set; }
    }
}
