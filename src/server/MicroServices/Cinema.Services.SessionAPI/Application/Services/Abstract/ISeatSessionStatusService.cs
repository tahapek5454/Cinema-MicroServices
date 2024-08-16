using Cinema.Services.SessionAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.SessionAPI.Application.Services.Abstract
{
    public interface ISeatSessionStatusService : IBaseService
    {
        public DbSet<SeatSessionStatus> Table { get; }
        public Task<int> SaveChangesAsync();
        public int SaveChanges();
    }
}
