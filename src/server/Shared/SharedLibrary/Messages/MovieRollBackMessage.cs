using SharedLibrary.Enums;
using SharedLibrary.Models.Dtos;

namespace SharedLibrary.Messages
{
    public class MovieRollBackMessage
    {
        public List<int> MovieIds { get; set; }
        public CRUDStatusEnum CrudStatus { get; set; }
        public List<UpdateResultDto>? UpdateResults { get; set; }
    }
}
