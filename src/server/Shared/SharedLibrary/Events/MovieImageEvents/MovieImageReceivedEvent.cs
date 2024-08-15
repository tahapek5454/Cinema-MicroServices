
using MassTransit;

namespace SharedLibrary.Events.MovieImageEvents
{
    public class MovieImageReceivedEvent: CorrelatedBy<Guid>
    {
        public MovieImageReceivedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }
        public Guid CorrelationId { get; }
    }
}
