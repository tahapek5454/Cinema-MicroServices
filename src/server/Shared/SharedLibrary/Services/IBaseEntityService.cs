using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Entities;

namespace SharedLibrary.Services
{
    public interface IBaseEntityService<T>: IBaseService where T : BaseEntity
    {
        public DbSet<T> Table { get; }
        public T? GetById(int id, bool asNoTracking = false);
        public Task<T?> GetByIdAsync(int id, bool asNoTracking = false);
        public IEnumerable<T> GetAll(bool asNoTracking = false);
        public Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = false);
        public void Add(T entity);
        public Task AddAsync(T entity);
        public void AddRange(IEnumerable<T> entities);
        public Task AddRangeAsync(IEnumerable<T> entities);
        public T Update(T entity);
        public Task<T> UpdateAsync(T entity);
        int UpdateAdvance<TModel, TRequest>(TModel model, TRequest request)
           where TModel : class
           where TRequest : class;
        public void Delete(int id);
        public void DeleteRange(params int[] ids);
        public Task DeleteAsync(int id);
        public Task<int> SaveChangesAsync();
        public int SaveChanges();
    }
}
