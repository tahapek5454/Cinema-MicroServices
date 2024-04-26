namespace Cinema.Services.SessionAPI.Models.Dtos
{
    public class SessionSeatDto
    {
        public int SessionId { get; set; }
        public int SeatId { get; set; }
        public int MovieTheaterId { get; set; }
        public string SeatNumber { get; set; }
        public bool Reserved { get; set; }
    }
}
