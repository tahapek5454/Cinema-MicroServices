using SharedLibrary.Enums;
using SharedLibrary.Models.Entities;

namespace Cinema.Services.SessionAPI.Models.Entities;

public class SeatSessionStatus: BaseEntity, ICloneable
{
    public int SessionId { get; set; }
    public Session Session { get; set; }
    public int SeatId { get; set; } 
    public Seat Seat { get; set; }
    public ReservedStatusEnum ReservedStatus { get; set; }

    public object Clone()
        => new SeatSessionStatus() 
        {
            Id = this.Id,
            SeatId = this.SeatId,
            ReservedStatus = this.ReservedStatus,
            CreatedDate = this.CreatedDate,
            Seat = this.Seat,
            Session = this.Session,
            SessionId = this.SessionId,
            UpdatedDate = this.UpdatedDate
        };
}

