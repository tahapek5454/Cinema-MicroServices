using MassTransit;
using SharedLibrary.Enums;

namespace SharedLibrary.Events.MovieChangeEvents.AddMovieEvents
{
    public class MovieChangeReceivedFromFileEvent : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; }

        public MovieChangeReceivedFromFileEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }
        public CRUDStatusEnum CrudStatus { get; set; }

        public List<int> MovieIds { get; set; }

    }
}
