using SharedLibrary.Enums;

namespace Cinema.Services.SessionAPI.Models.Dtos
{
    public class SeatSessionStatusDto
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int SeatId { get; set; }
        public string SeatNumber { get; set; }
        public ReservedStatusEnum ReservedStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
