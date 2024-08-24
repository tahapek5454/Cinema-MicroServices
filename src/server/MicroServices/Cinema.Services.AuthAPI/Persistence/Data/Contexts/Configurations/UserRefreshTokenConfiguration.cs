using Cinema.Services.AuthAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Services.AuthAPI.Persistence.Data.Contexts.Configurations
{
    public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder.HasOne(rf => rf.User)
                    .WithOne(rf => rf.UserRefreshToken)
                    .HasForeignKey<UserRefreshToken>(rf => rf.UserId);
        }
    }
}
