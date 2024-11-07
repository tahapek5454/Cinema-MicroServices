using MassTransit;

namespace SagaStateMachine.Host.StateInstances
{
    public class CategoryChangedStateInstance : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public DateTime CreatedTime { get; set; }
        public int CategoryId { get; set; }
    }
}
