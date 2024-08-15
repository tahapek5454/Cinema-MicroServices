namespace Cinema.Services.RezervationAPI.Models.Dtos
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public List<int> SeatIds { get; set; }
        public int MovieTheaterId { get; set; }
        public int Price { get; set; }
        public bool IsPaymentRealised { get; set; }
    }
}
