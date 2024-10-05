using MassTransit;
using SharedLibrary.Enums;

namespace SagaStateMachine.Host.StateInstances
{
    public class MovieChangeStateInstance : SagaStateMachineInstance
    {
        public Guid CorrelationId {  get; set; }
        public string CurrentState { get; set; }

        public CRUDStatusEnum CrudStatus { get; set; }
        public string MovieIds { get; set; } // Db de kaydı tutulacak tek bir hücrede birden fazla id yi goruntulemek için '1,2,3' şeklinde saklayacagiz
        public string CategoryIds { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
