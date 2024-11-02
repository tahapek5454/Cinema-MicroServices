namespace Cinema.Services.MovieAPI.Application.Dtos.Comments
{
    public class MovieCommentDto
    {
        public  int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Comment { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int LikeCount { get; set; }
        public int? ParenId { get; set; }
    }
}
