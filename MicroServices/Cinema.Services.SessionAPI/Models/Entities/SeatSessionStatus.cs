using SharedLibrary.Enums;
using SharedLibrary.Models.Entities;

namespace Cinema.Services.SessionAPI.Models.Entities;

public class SeatSessionStatus: BaseEntity
{
    public int SessionId { get; set; }
    public Session Session { get; set; }
    public int SeatId { get; set; } 
    public Seat Seat { get; set; }
    public ReservedStatusEnum ReservedStatus { get; set; }

}

