using SharedLibrary.Enums;

namespace SharedLibrary.Messages
{
    public class MovieRollBackMessage
    {
        public List<int> MovieIds { get; set; }
        public CRUDStatusEnum CrudStatus { get; set; }
    }
}
