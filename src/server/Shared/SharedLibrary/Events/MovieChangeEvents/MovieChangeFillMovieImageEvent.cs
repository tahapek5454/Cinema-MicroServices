using MassTransit;
using SharedLibrary.Enums;

namespace SharedLibrary.Events.MovieChangeEvents
{
    public class MovieChangeFillMovieImageEvent : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; }

        public MovieChangeFillMovieImageEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }
        public CRUDStatusEnum CrudStatus { get; set; }

        public List<int> MovieIds { get; set; }

    }
}
