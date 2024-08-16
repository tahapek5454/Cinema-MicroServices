using SharedLibrary.Models.Entities;

namespace Cinema.Services.SessionAPI.Domain.Entities
{
    public class MovieTheater : BaseEntity
    {
        public MovieTheater()
        {
            Seats = new();
            Sessions = new();
        }
        public int BranchId { get; set; }
        public int MovieTheaterNumber { get; set; }
        public int Capacity { get; set; }
        public List<Seat> Seats { get; set; }
        public List<Session> Sessions { get; set; }
    }
}
