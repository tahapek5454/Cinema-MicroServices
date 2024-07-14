using Cinema.Services.RezervationAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Services;

namespace Cinema.Services.RezervationAPI.Service.Abstract
{
    public interface IReservationService: IBaseService
    {
        public DbSet<Reservation> Table { get; }
        public Task<int> SaveChangesAsync();
        public int SaveChanges();
    }
}
