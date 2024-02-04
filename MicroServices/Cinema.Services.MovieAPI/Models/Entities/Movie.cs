using SharedLibrary.Models.Entities;

namespace Cinema.Services.MovieAPI.Models.Entities
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public string Name_EN { get; set; }
        public string Description { get; set; }
        public string Description_EN { get; set; }
        public float Point { get; set; }
    }
}
