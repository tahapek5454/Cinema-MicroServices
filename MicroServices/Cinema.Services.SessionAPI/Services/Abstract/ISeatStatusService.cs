using Cinema.Services.SessionAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.SessionAPI.Services.Abstract
{
    public interface ISeatStatusService: IBaseService
    {
        public DbSet<SeatStatus> Table { get; }
        public Task<int> SaveChangesAsync();
        public int SaveChanges();
    }
}
