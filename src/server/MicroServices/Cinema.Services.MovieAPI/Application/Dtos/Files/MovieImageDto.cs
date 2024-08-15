namespace Cinema.Services.MovieAPI.Application.Dtos.Files
{
    public class MovieImageDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Storage { get; set; }
        public int MovieId { get; set; }
    }
}
