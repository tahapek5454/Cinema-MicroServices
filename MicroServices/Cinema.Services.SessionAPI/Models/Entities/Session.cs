using SharedLibrary.Models.Entities;

namespace Cinema.Services.SessionAPI.Models.Entities;

public class Session: BaseEntity
{
    public Session()
    {
        SeatSessionStatuses = new();
    }
    public int MovieId { get; set; }
    public int MovieTheaterId { get; set; }
    public  MovieTheater MovieTheater { get; set; }
    public DateTime Date { get; set; }
    public decimal Price { get; set; }

    public List<SeatSessionStatus> SeatSessionStatuses { get; set; }

}

