using SharedLibrary.Models.SharedModels.Categories;

namespace SharedLibrary.Events.CategoryChangeEvent
{
    public class CategoryChangeStartedEvent
    {
        public DateTime CreatedTime { get; set; }
        public int CategoryId { get; set; }
        public CategorySharedVM CategorySharedVM { get; set; }
    }
}
