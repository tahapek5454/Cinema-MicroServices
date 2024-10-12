using SharedLibrary.Enums;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Models.SharedModels.Movies;

namespace SharedLibrary.Events.MovieChangeEvents
{
    public class MovieChangeStartedEvent
    {
        public string MovieIds { get; set; }
        public string CategoryIds { get; set; }
        public CRUDStatusEnum CrudStatus { get; set; }
        public DateTime CreatedTime { get; set; }

        public List<UpdateResultDto>? UpdateResults { get; set; }
        public List<MovieSharedVM>? OldMovieValues { get; set; }
    }
}
