using Cinema.Services.SessionAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Entities;
using System.Reflection;

namespace Cinema.Services.SessionAPI.Data.Contexts
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<SeatSessionStatus> SeatSessionStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.CreatedDate = DateTime.Now,
                    _ => DateTime.Now
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
