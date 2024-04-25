namespace Cinema.Services.SessionAPI.Models.Dtos
{
    public class SessionDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int MovieTheaterId { get; set; }
        public int Capacity { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}
