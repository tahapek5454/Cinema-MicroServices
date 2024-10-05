using MassTransit;
using SharedLibrary.Enums;

namespace SharedLibrary.Events.MovieChangeEvents
{
    public class MovieChangeReceivedFromCategoryEvent : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; }

        public MovieChangeReceivedFromCategoryEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }
        public CRUDStatusEnum CrudStatus { get; set; }

        public List<int> MovieIds { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
