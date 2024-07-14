namespace Cinema.Services.RezervationAPI.Models.Request
{
    public class ReservationRequest
    {
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public List<int> SeatIds { get; set; }
        public int MovieTheaterId { get; set; }
        public int Price { get; set; }
    }
}
