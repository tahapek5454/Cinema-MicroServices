namespace Cinema.Services.SessionAPI.Models.Dtos
{
    public class SeatDto
    {
        public int Id { get; set; }
        public string SeatNumber { get; set; }
        public int MovieTheaterId { get; set; }
    }
}
