namespace Cinema.Services.SessionAPI.Application.Dtos
{
    public class SessionDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int MovieTheaterId { get; set; }
        public MovieTheaterDto MovieTheater { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}
