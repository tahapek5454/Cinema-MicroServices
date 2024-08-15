using MassTransit;

namespace SharedLibrary.Events.MovieImageEvents
{
    public class MovieImageDeletedEvent:CorrelatedBy<Guid>
    {
        public MovieImageDeletedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public Guid CorrelationId { get; }  
        public string FileName { get; set; }

    }
    
}
