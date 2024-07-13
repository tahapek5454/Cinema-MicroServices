
using MassTransit;

namespace SharedLibrary.Events.ReservationEvents
{
    public class ReserveFailedEvent : CorrelatedBy<Guid>
    {
        public ReserveFailedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;   
        }
        public Guid CorrelationId { get; }

        public int ReservationId { get; set; }

        public string ErrorMessage { get; set; }
    }
}
