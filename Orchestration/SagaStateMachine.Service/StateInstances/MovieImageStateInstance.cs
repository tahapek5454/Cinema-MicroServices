
using MassTransit;

namespace SagaStateMachine.Service.StateInstances
{
    public class MovieImageStateInstance : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }

        public int FileId { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Storage { get; set; }
        public string RelationId { get; set; }
    }
}
