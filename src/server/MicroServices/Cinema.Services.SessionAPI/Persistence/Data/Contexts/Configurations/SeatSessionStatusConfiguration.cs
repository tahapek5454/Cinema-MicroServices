using Cinema.Services.SessionAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Cinema.Services.SessionAPI.Persistence.Data.Contexts.Configurations
{
    public class SeatSessionStatusConfiguration : IEntityTypeConfiguration<SeatSessionStatus>
    {
        public void Configure(EntityTypeBuilder<SeatSessionStatus> builder)
        {
            builder
            .HasKey(ss => new { ss.SessionId, ss.SeatId });

            builder
                .HasIndex(ss => new { ss.SessionId, ss.SeatId })
            .IsUnique();

            builder
                .HasOne(ss => ss.Session)
                .WithMany(s => s.SeatSessionStatuses)
                .HasForeignKey(ss => ss.SessionId).OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(ss => ss.Seat)
                .WithMany(s => s.SeatSessionStatuses)
                .HasForeignKey(ss => ss.SeatId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
