

using MassTransit;

namespace SharedLibrary.Events.MovieImageEvents
{
    public class MovieImageUploadedEvent: CorrelatedBy<Guid>
    {
        public MovieImageUploadedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public Guid CorrelationId { get; }
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Storage { get; set; }
        public string RelationId { get; set; }

    }
}
