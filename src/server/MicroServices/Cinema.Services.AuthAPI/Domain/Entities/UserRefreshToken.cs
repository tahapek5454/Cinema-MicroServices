using SharedLibrary.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Services.AuthAPI.Domain.Entities
{
    public class UserRefreshToken: BaseEntity
    {

        public int UserId { get; set; }
        public User User { get; set; }

        public string Code { get; set; }
        public DateTime Expiration { get; set; }

        [NotMapped]
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
    }
}
