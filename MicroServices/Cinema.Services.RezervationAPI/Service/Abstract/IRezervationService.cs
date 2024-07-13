using Cinema.Services.RezervationAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.RezervationAPI.Service.Abstract
{
    public interface IRezervationService: IBaseService
    {
        public DbSet<Rezervation> Table { get; }
        public Task<int> SaveChangesAsync();
        public int SaveChanges();
    }
}
