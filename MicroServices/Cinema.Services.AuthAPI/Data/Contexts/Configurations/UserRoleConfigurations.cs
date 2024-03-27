using Cinema.Services.AuthAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Services.AuthAPI.Data.Contexts.Configurations
{
    public class UserRoleConfigurations : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(ky => new { ky.UserId, ky.RoleId });

            builder
                .HasOne(ur => ur.User)
                .WithMany(u => u.Roles)
                .HasForeignKey(ur => ur.UserId);

            builder
                .HasOne(ur => ur.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(ur => ur.RoleId);

            builder.HasData(GetSeedDatas());
        }

        private IEnumerable<UserRole> GetSeedDatas()
        {
            yield return new UserRole()
            {
                UserId = 1,
                RoleId = 1,
            };

            yield return new UserRole()
            {
                UserId = 2,
                RoleId = 2,
            };
        }
    }
}
