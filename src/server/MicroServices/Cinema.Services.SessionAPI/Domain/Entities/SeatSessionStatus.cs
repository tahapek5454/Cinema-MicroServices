using SharedLibrary.Enums;
using SharedLibrary.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Services.SessionAPI.Domain.Entities;

public class SeatSessionStatus : BaseEntity, ICloneable
{
    public int SessionId { get; set; } // double pk
    public Session Session { get; set; }
    public int SeatId { get; set; } // double pk
    public Seat Seat { get; set; }
    public ReservedStatusEnum ReservedStatus { get; set; }
    public int? UserId { get; set; }
    [Timestamp]
    public int RowVersion { get; set; }


    [NotMapped]
    public override int Id { get => base.Id; set => base.Id = value; }

    public object Clone()
        => new SeatSessionStatus()
        {
            SeatId = SeatId,
            ReservedStatus = ReservedStatus,
            CreatedDate = CreatedDate,
            Seat = Seat,
            Session = Session,
            SessionId = SessionId,
            UpdatedDate = UpdatedDate,
            UserId = UserId,
        };
}

