namespace SharedLibrary.Models.Entities
{
    public class BaseEntity
    {
        public virtual int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }

    }
}
