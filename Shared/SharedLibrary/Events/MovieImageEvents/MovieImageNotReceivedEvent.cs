
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
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string Message { get; set; }

    }
}
