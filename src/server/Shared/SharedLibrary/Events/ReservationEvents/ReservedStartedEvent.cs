

namespace SharedLibrary.Events.ReservationEvents
{
    public class ReservedStartedEvent
    {
        public int ReservationId { get; set; }
        public DateTime ReservationCreatedDate { get; set; }
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public string SeatIds { get; set; }
    }
}
