using MassTransit;


namespace SharedLibrary.Events.ReservationEvents
{
    public class ReservedEvent : CorrelatedBy<Guid>
    {
        public ReservedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }
        public Guid CorrelationId {  get; }
        public int ReservationId { get; set; }
        public DateTime ReservationCreatedDate { get; set; }
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public string SeatIds { get; set; }
        public int MovieTheaterId { get; set; }
        public int Price { get; set; }
    }
}
