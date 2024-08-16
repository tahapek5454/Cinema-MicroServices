namespace Cinema.Services.SessionAPI.Application.Dtos
{
    public class SeatDto
    {
        public int Id { get; set; }
        public string SeatNumber { get; set; }
        public int MovieTheaterId { get; set; }
    }
}
