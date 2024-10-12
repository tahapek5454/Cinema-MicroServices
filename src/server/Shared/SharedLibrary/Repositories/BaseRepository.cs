using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Models.Entities;
using System.Collections.Generic;
using System.Security;
using System.Text.Json;

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

        public void DeleteRange(IEnumerable<int> ids)
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

        public List<UpdateResultDto> UpdateAdvance<TModel, TRequest>(TModel model, TRequest request) // should be use primitive types
            where TModel : class
            where TRequest : class
        {

            List<UpdateResultDto> updateResults = new List<UpdateResultDto>();

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

                if (entityProperty != null && updatedValue != null && requestProperty.Name != pk.Name)
                {
                    var updateResult = new UpdateResultDto()
                    {
                        PropertyTypeName = entityProperty.PropertyType.Name,
                        PropertyName = entityProperty.Name,
                        OldValue = entityProperty.GetValue(model),
                        NewValue = updatedValue,
                        ModelPk = pk.GetValue(model) == null ? null : (int)pk.GetValue(model),
                        ModelTypeName = entityType.Name,
                    };

                    updateResults.Add(updateResult);    

                    entityProperty.SetValue(model, updatedValue);
                    updatedPropertyCount++;
                }
            }

            return updateResults;
        }

        public List<UpdateResultDto> UpdatePartialRollback<TModel>(TModel model, List<UpdateResultDto> partial) where TModel : BaseEntity // should be use primitive types
        {
            var entityType = typeof(TModel);
            var entityProperties = entityType.GetProperties();



            foreach (var item in partial)
            {
                var property = entityProperties.FirstOrDefault(x => x.Name.Equals(item.PropertyName));

                if (property is null) // Can be log
                    return partial;

                try
                {
                    var proptype = property.PropertyType;
                    var oldValue = item.OldValue;

                    if (oldValue is JsonElement jsonElement)
                    {      
                        
                        object val = ConvertJsonElement(jsonElement, proptype);


                        property.SetValue(model, val);
                        
                    
                    }
                    else
                    {
                        object? convertedValue = Convert.ChangeType(oldValue, proptype);

                        if (convertedValue is null)
                            return partial;

                        property.SetValue(model, convertedValue);
                    }

                  
                }
                catch (Exception e)
                {
                    throw;
                }
        
            }

            return partial.Select(x => new UpdateResultDto()
            {
                ModelPk = x.ModelPk,
                ModelTypeName = x.ModelTypeName,
                OldValue = x.NewValue,
                NewValue = x.OldValue,
                PropertyName = x.PropertyName,
                PropertyTypeName = x.PropertyTypeName
            }).ToList();
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



        private object ConvertJsonElement(JsonElement jsonElement, Type targetType)
        {
            switch (jsonElement.ValueKind)
            {
                case JsonValueKind.Number:
                    if (targetType == typeof(int))
                        return jsonElement.GetInt32();
                    if (targetType == typeof(long))
                        return jsonElement.GetInt64();
                    if (targetType == typeof(double))
                        return jsonElement.GetDouble();
                    break;

                case JsonValueKind.String:
                    if (targetType == typeof(string))
                        return jsonElement.GetString();
                    break;

                case JsonValueKind.True:
                case JsonValueKind.False:
                    if (targetType == typeof(bool))
                        return jsonElement.GetBoolean();
                    break;
                case JsonValueKind.Array:
                    return ConvertJsonArray(jsonElement, targetType);
            }

            throw new InvalidOperationException($"Cannot convert JsonElement of kind {jsonElement.ValueKind} to {targetType}");
        }


        private object ConvertJsonArray(JsonElement jsonArray, Type targetType)
        {
            if (targetType.IsArray)
            {
                Type elementType = targetType.GetElementType();
                List<object> items = new List<object>();

                foreach (var jsonElement in jsonArray.EnumerateArray())
                {
                    object item = ConvertJsonElement(jsonElement, elementType);
                    items.Add(item);
                }

                Array array = Array.CreateInstance(elementType, items.Count);
                for (int i = 0; i < items.Count; i++)
                {
                    array.SetValue(items[i], i);
                }

                return array;
            }

            throw new InvalidOperationException($"Cannot convert JsonArray to {targetType}");
        }

    }
}
