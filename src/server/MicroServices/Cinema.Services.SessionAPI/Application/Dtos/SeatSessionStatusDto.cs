using SharedLibrary.Enums;

namespace Cinema.Services.SessionAPI.Application.Dtos
{
    public class SeatSessionStatusDto
    {
        public int SessionId { get; set; }
        public int SeatId { get; set; }
        public string SeatNumber { get; set; }
        public ReservedStatusEnum ReservedStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
