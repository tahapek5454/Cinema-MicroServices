using SharedLibrary.Models.Entities;

namespace Cinema.Services.AuthAPI.Models.Entities
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<UserRole> Roles { get; set; }
    }
}
