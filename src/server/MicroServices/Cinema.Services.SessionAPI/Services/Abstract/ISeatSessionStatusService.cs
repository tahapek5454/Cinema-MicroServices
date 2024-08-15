using Cinema.Services.SessionAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.SessionAPI.Services.Abstract
{
    public interface ISeatSessionStatusService: IBaseService
    {
        public DbSet<SeatSessionStatus> Table { get; }
        public Task<int> SaveChangesAsync();
        public int SaveChanges();
    }
}
