using SharedLibrary.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Services.SessionAPI.Models.Entities;

public class Seat: BaseEntity
{
    public Seat()
    {
        SeatSessionStatuses = new();
    }
    public string SeatNumber { get; set; }
    public int MovieTheaterId { get; set; }
    public MovieTheater MovieTheater { get; set; }

    public List<SeatSessionStatus> SeatSessionStatuses { get; set; }

    [NotMapped]
    public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
}

