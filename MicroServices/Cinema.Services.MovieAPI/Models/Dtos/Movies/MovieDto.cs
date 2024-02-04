using Cinema.Services.MovieAPI.Models.Dtos.Categories;
using Cinema.Services.MovieAPI.Models.Dtos.Files;

namespace Cinema.Services.MovieAPI.Models.Dtos.Movies
{
    public class MovieDto
    {
        public MovieDto()
        {
            Files = new();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Point { get; set; }
        public double Time { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public CategoryDto Category { get; set; }
        public List<FileDto> Files { get; set; }
    }
}
