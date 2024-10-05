using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Entities;
using SharedLibrary.Repositories;

namespace SharedLibrary.Services
{
    public abstract class BaseEntityService<T> : BaseService, IBaseEntityService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _repository;
        public BaseEntityService(IHttpClientFactory _httpClientFactory, IBaseRepository<T> repository) : base(_httpClientFactory)
        {
            _repository = repository;
        }

        public DbSet<T> Table => _repository.Table;

        public void Add(T entity)
            => _repository.Add(entity);

        public async Task AddAsync(T entity)
            => await _repository.AddAsync(entity);

        public void AddRange(IEnumerable<T> entities)
            => _repository.AddRange(entities);

        public async Task AddRangeAsync(IEnumerable<T> entities)
            => await _repository.AddRangeAsync(entities);

        public void Delete(int id)
            => _repository.Delete(id);

        public async Task DeleteAsync(int id)
            => await _repository.DeleteAsync(id);

        public  void DeleteRange(params int[] ids)
            =>  _repository.DeleteRange(ids);

        public void DeleteRange(IEnumerable<int> ids)
            => _repository.DeleteRange(ids);

        public IEnumerable<T> GetAll(bool asNoTracking = false)
            => _repository.GetAll(asNoTracking);

        public async Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = false)
            => await _repository.GetAllAsync(asNoTracking);

        public T? GetById(int id, bool asNoTracking = false)
            => _repository.GetById(id, asNoTracking);

        public async Task<T?> GetByIdAsync(int id, bool asNoTracking = false)
            => await _repository.GetByIdAsync(id, asNoTracking);  

        public int SaveChanges()
            => _repository.SaveChanges();

        public async Task<int> SaveChangesAsync()
            => await _repository.SaveChangesAsync();

        public T Update(T entity)
            => _repository.Update(entity);

        public int UpdateAdvance<TModel, TRequest>(TModel model, TRequest request)
            where TModel : class
            where TRequest : class
            => _repository.UpdateAdvance(model, request);

        public async Task<T> UpdateAsync(T entity)
            => await _repository.UpdateAsync(entity);   
    }
}
