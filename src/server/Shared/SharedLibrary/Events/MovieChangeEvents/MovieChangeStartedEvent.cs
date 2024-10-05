using SharedLibrary.Enums;

namespace SharedLibrary.Events.MovieChangeEvents
{
    public class MovieChangeStartedEvent
    {
        public string MovieIds { get; set; }
        public string CategoryIds { get; set; }
        public CRUDStatusEnum CrudStatus { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
