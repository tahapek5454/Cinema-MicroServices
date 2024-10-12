using MassTransit;
using SharedLibrary.Enums;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Models.SharedModels.Movies;

namespace SharedLibrary.Events.MovieChangeEvents
{
    public class MovieChangeFillCategoryEvent : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; }

        public MovieChangeFillCategoryEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }
        public CRUDStatusEnum CrudStatus { get; set; }

        public List<int> MovieIds { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<UpdateResultDto>? UpdateResults { get; set; }
        public List<MovieSharedVM>? OldMovieValues { get; set; }

    }
}
