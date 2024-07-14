using SharedLibrary.Models.Entities;

namespace Cinema.Services.RezervationAPI.Models.Entities
{
    public class Reservation : BaseEntity
    {
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public string SeatIds { get; set; }
        public int MovieTheaterId { get; set; }
        public int Price { get; set; }
        public bool IsPaymentRealised { get; set; }
    }
}
