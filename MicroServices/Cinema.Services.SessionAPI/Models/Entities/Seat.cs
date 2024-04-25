using SharedLibrary.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Services.SessionAPI.Models.Entities;

public class Seat: BaseEntity
{
    public string SeatNumber { get; set; }
    public int MovieTheaterId { get; set; }

    [NotMapped]
    public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
}

