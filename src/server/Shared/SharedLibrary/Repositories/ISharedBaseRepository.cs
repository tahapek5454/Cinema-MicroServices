using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SharedLibrary.Models.Entities;
using System.Linq.Expressions;

namespace SharedLibrary.Repositories
{
    public interface ISharedBaseRepository<T> where T : SharedBaseEntity
    {
        IMongoQueryable<T> Query();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(int id, T entity);
        Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate);
        Task<T> DeleteAsync(T entity);
        Task<T> DeleteAsync(int id);
        Task<T> DeleteAsync(Expression<Func<T, bool>> predicate);
        Task<DeleteResult> DeleteRangeByIdsAsync(IEnumerable<int> ids);
    }
}
