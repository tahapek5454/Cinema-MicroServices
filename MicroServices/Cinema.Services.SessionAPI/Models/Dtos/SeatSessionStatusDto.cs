namespace Cinema.Services.SessionAPI.Models.Dtos
{
    public class SeatSessionStatusDto
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int SeatId { get; set; }
        public bool Reserved { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
