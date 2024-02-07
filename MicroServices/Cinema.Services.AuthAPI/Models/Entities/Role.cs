using SharedLibrary.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Services.AuthAPI.Models.Entities
{
    public class Role: BaseEntity
    {

        public string Name { get; set; }

        public List<UserRole> Users { get; set; }


        [NotMapped]
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
    }
}
