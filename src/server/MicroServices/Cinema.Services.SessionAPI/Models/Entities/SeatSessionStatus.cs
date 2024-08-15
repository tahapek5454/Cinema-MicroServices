using SharedLibrary.Enums;
using SharedLibrary.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Services.SessionAPI.Models.Entities;

public class SeatSessionStatus: BaseEntity, ICloneable
{
    public int SessionId { get; set; }
    public Session Session { get; set; }
    public int SeatId { get; set; } 
    public Seat Seat { get; set; }
    public ReservedStatusEnum ReservedStatus { get; set; }

    [NotMapped]
    public override int Id { get => base.Id; set => base.Id = value; }

    public object Clone()
        => new SeatSessionStatus() 
        {
            SeatId = this.SeatId,
            ReservedStatus = this.ReservedStatus,
            CreatedDate = this.CreatedDate,
            Seat = this.Seat,
            Session = this.Session,
            SessionId = this.SessionId,
            UpdatedDate = this.UpdatedDate
        };
}

