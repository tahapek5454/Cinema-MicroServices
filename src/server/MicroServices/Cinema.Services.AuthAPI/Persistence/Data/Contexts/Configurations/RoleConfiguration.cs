using Cinema.Services.AuthAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Services.AuthAPI.Persistence.Data.Contexts.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(GetSeedDatas());
        }

        private IEnumerable<Role> GetSeedDatas()
        {
            yield return new Role()
            {
                Id = 1,
                CreatedDate = new DateTime(2024, 3, 27),
                Name = "admin",
                UpdatedDate = new DateTime(2024, 3, 27),
            };

            yield return new Role()
            {
                Id = 2,
                CreatedDate = new DateTime(2024, 3, 27),
                Name = "customer",
                UpdatedDate = new DateTime(2024, 3, 27),
            };
        }
    }
}
