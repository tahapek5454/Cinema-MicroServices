using MassTransit;

namespace SagaStateMachine.Host.StateInstances
{
    public class ReservationStateInstance : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }


        public int ReservationId { get; set; }
        public DateTime ReservationCreatedDate { get; set; }
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public string SeatIds { get; set; }

    }
}
