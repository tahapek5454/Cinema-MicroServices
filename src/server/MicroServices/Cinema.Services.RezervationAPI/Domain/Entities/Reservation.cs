using SharedLibrary.Models.Entities;

namespace Cinema.Services.RezervationAPI.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public string SeatIds { get; set; }
        public bool IsPaymentRealised { get; set; }
    }
}
