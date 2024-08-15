using Cinema.Services.AuthAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Services.AuthAPI.Data.Contexts.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(GetSeedDatas());
        }

        private IEnumerable<User> GetSeedDatas()
        {
            yield return new User()
            {
                Id = 1,
                Name = "admin",
                Email = "admin@gmail.com",
                CreatedDate = new DateTime(2024, 3, 27),
                Password = "secret.123",
                Surname = "admin",
                UserName = "admin",
                UpdatedDate = new DateTime(2024, 3, 27)

            };

            yield return new User()
            {
                Id = 2,
                Name = "customer",
                Email = "customer@gmail.com",
                CreatedDate = new DateTime(2024, 3, 27),
                Password = "123",
                Surname = "customer",
                UserName = "customer",
                UpdatedDate = new DateTime(2024, 3, 27)

            };
        }
    }
}
