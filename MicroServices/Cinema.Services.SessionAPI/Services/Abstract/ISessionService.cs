using Cinema.Services.SessionAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.SessionAPI.Services.Abstract
{
    public interface ISessionService: IBaseService
    {
        public DbSet<Session> Table { get; }
        public Task<int> SaveChangesAsync();
        public int SaveChanges();
    }
}
