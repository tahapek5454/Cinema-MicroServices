using MassTransit;


namespace SharedLibrary.Events.ReservationEvents
{
    public class ReserveReceivedEvent : CorrelatedBy<Guid>
    {
        public ReserveReceivedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public Guid CorrelationId {get;}
        // belki koltuk numrası falan eklenebilir. İşte Sessiondan ne eklenecekse koyulabilir
        public int ReservationId { get; set; }
        public DateTime ReservationCreatedDate { get; set; }
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public string SeatIds { get; set; }
    }
}
