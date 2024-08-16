using Cinema.Services.SessionAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.SessionAPI.Application.Services.Abstract
{
    public interface ISessionService : IBaseService
    {
        public DbSet<Session> Table { get; }
        public Task<int> SaveChangesAsync();
        public int SaveChanges();
    }
}
