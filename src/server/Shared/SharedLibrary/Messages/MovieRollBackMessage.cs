using SharedLibrary.Enums;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Models.SharedModels.Movies;

namespace SharedLibrary.Messages
{
    public class MovieRollBackMessage
    {
        public List<int> MovieIds { get; set; }
        public CRUDStatusEnum CrudStatus { get; set; }
        public List<UpdateResultDto>? UpdateResults { get; set; }
        public List<MovieSharedVM>? OldMovieValues { get; set; }
    }
}
