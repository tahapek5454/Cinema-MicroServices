
using MassTransit;

namespace SharedLibrary.Events.MovieImageEvents
{
    public class MovieImageNotReceivedEvent : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; }

        public MovieImageNotReceivedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public string FileName { get; set; }
        public string Message { get; set; }

    }
}
