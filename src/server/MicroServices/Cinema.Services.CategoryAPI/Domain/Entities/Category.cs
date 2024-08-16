using SharedLibrary.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Services.CategoryAPI.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string? Name_EN { get; set; }

        [NotMapped]
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
    }
}
