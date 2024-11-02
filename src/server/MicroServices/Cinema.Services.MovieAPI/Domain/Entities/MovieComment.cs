using SharedLibrary.Models.Entities;

namespace Cinema.Services.MovieAPI.Domain.Entities
{
    public class MovieComment: BaseEntity
    {
        public string Comment { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int LikeCount { get; set; }
        public int? ParenId { get; set; } // Bu yorum yanıtlanırsa ParenId null, Yanıtların ParentId si ilgili yorum Id
    }
}
