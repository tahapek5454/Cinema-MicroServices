using SharedLibrary.Models.Entities;

namespace Cinema.Services.SessionAPI.Models.Entities;

public class Session: BaseEntity
{
    public int MovieId { get; set; }
    public int MovieTheaterId { get; set; }
    public int Capacity { get; set; }
    public DateTime Date { get; set; }
    public decimal Price { get; set; }

}

