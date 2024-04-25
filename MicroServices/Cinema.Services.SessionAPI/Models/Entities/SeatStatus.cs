using SharedLibrary.Models.Entities;

namespace Cinema.Services.SessionAPI.Models.Entities;

public class SeatStatus: BaseEntity
{
    public int SessionId { get; set; }
    public int SeatId { get; set; }
    public bool Reserved { get; set; }

}

