using System.Net.Mail;
using System.Net;
using System.Text;
using SharedLibrary.Events.MailEvents;

namespace Cinema.Services.MailWorkerService.Services
{
    public class MailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendCompletedReservationMailAsync(ReservationCompleteMailEvent @event)
        {

            string mail = $$"""
                    <h3>Merhabalar Sayın {{@event.Name}} {{@event.Surname}}</h3>
                    <p><b>D-TIX</b>' üzerinden yapmış olduğunuz <b>{{@event.MovieName}}</b> filmi için rezervasyonunuz tamamlanmıştır.</p>
                    <p>Rezervasyonunuz ile ilgili gerekli bilgiler aşşağıda yer almaktadır.</p>

                    <ul>
                        <li><b>Rezervasyon Yeri:</b> {{@event.BranchName}} - {{@event.MovieTheaterNumber}} {{@event.CityName}}/{{@event.DistrictName}}</li>
                        <li><b>Rezervasyon Tarihi:</b> {{@event.ReservationTime.ToString("dd-MM-yyyy HH:MM")}}</li>
                        <li><b>Koltuk/Koltuklar:</b> {{@event.SeatNumbers}}</li>
                        <li><b>Toplam Tutar:</b> {{@event.TotalPrice}} TL</li>
                    </ul>

                    <P>Bizleri tercih ettiğiniz için teşekkür eder ve keyifli seyirler dileriz.</P>
                    <span><b>D-TIX</b> İletişim: 02735487</span>
                """;

            await SendMessageAsync(@event.Email, $"Rezervasyonunuz Tamamlandı", mail);


        }

        public async Task SendMessageAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new MailMessage();
            // olusturulan objede html var mı
            mail.IsBodyHtml = isBodyHtml;
            // kime gidecegi belirtilmis
            foreach (var to in tos)
            {
                mail.To.Add(to);

            }
            // subject ve bodylerini yazdik
            mail.Subject = subject;
            mail.Body = body;

            // kimin gonderecegini belirtelim
            mail.From = new MailAddress(_configuration["Mail:UserName"], "D-TIX", System.Text.Encoding.UTF8);

            // GONDERME ISLEMI
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential(_configuration["Mail:UserName"], _configuration["Mail:ApplicationPassword"]);
            smtp.Port = Int32.Parse(_configuration["Mail:Port"]);
            smtp.EnableSsl = true;
            smtp.Host = _configuration["Mail:Host"];
            await smtp.SendMailAsync(mail);

        }

        public async Task SendMessageAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMessageAsync(new string[] { to }, subject, body, isBodyHtml);
        }


    }
}
