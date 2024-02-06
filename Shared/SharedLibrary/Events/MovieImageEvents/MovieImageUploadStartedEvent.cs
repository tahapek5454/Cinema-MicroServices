

namespace SharedLibrary.Events.MovieImageEvents
{
    public class MovieImageUploadStartedEvent
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Storage { get; set; }
        public string RelationId { get; set; }
    }
}
