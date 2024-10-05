using MassTransit;
using SharedLibrary.Enums;

namespace SharedLibrary.Events.MovieChangeEvents
{
    public class MovieChangeFillCategoryEvent : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; }

        public MovieChangeFillCategoryEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }
        public CRUDStatusEnum CrudStatus { get; set; }

        public List<int> MovieIds { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
