using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Entities;

namespace SharedLibrary.Repositories
{
    public abstract class BaseRepository<T>: IBaseRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.AddRangeAsync(entities);
        }

        public void Delete(int id)
        {
            var entity = Table.Find(id);
            if(entity is not null)
                _context.Remove(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await Table.FindAsync(id);
            if (entity is not null)
                _context.Remove(entity);
        }

        public void DeleteRange(params int[] ids)
        {
            var entities = Table.Where(x => ids.Contains(x.Id)).ToList();
            if (entities.Any())
                _context.RemoveRange(entities);
        }

        public IEnumerable<T> GetAll(bool asNoTracking = false)
        {
            if(asNoTracking)
                return Table.AsNoTracking().ToList();

            return Table.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = false)
        {
            if (asNoTracking)
                return await Table.AsNoTracking().ToListAsync();

            return await Table.ToListAsync();
        }

        public T? GetById(int id, bool asNoTracking = false)
        {
            if (asNoTracking)
                return  Table.AsNoTracking().FirstOrDefault(x => x.Id==id);

            return  Table.FirstOrDefault(x => x.Id == id);
        }

        public async Task<T?> GetByIdAsync(int id, bool asNoTracking = false)
        {
            if (asNoTracking)
                return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return await Table.FirstOrDefaultAsync(x => x.Id == id);
        }

        public T Update(T entity)
        {
            _context.Update(entity);

            return entity;
        }

        public int UpdateAdvance<TModel, TRequest>(TModel model, TRequest request)
            where TModel : class
            where TRequest : class
        {
            var entityType = typeof(TModel);
            var requestType = typeof(TRequest);

            var entityProperties = entityType.GetProperties();
            var requestProperties = requestType.GetProperties();

            var pk = entityType.GetProperty("Id"); // we use primary key like Id if you change pk name you have to change this

            var updatedPropertyCount = 0;

            // request and entity properties have to same
            foreach (var requestProperty in requestProperties)
            {
                var entityProperty = entityProperties.FirstOrDefault(p => p.Name == requestProperty.Name);
                var updatedValue = requestProperty.GetValue(request);

                if (entityProperty != null && updatedValue != null && requestProperty != pk)
                {
                    entityProperty.SetValue(model, updatedValue);
                    updatedPropertyCount++;
                }
            }

            return updatedPropertyCount;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await Task.Run<T>(() => {

                            _context.Update(entity);
                            return entity;
                
                         });
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
