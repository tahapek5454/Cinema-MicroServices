using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using MongoDB.Driver.Linq;
using SharedLibrary.Attributes;
using SharedLibrary.Models.Entities;
using SharedLibrary.Settings;
using System.Linq.Expressions;

namespace SharedLibrary.Repositories
{
    public class SharedBaseRepository<T> : ISharedBaseRepository<T> where T : SharedBaseEntity
    {
        private readonly IMongoCollection<T> _collection;
        private readonly MongoDbSettings settings;

        public SharedBaseRepository(IOptions<MongoDbSettings> options)
        {
            this.settings = options.Value;

            var mongoConnectionUrl = new MongoUrl(this.settings.ConnectionString);
            var mongoClientSettings = MongoClientSettings.FromUrl(mongoConnectionUrl);
            mongoClientSettings.ClusterConfigurator = cb => {
                cb.Subscribe<CommandStartedEvent>(e => {
                    Console.WriteLine("Sorgu ataıldı.");
                    Console.WriteLine($"{e.CommandName} - {e.Command.ToJson()}"); // Log operation

                });
            };
            var client = new MongoClient(mongoClientSettings);

            //var client = new MongoClient(this.settings.ConnectionString);
            var db = client.GetDatabase(this.settings.Database);

            var collectionName = ((CollectionInfoAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(CollectionInfoAttribute)))?.CollectionName;
            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = typeof(T).Name.ToLowerInvariant();
            }
            this._collection = db.GetCollection<T>(collectionName);

        }

        public IQueryable<T> Query()
         => _collection.AsQueryable();
        public async Task<T> AddAsync(T entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await _collection.InsertOneAsync(entity, options);
            return entity;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            var options = new BulkWriteOptions { IsOrdered = false, BypassDocumentValidation = false };
            return (await _collection.BulkWriteAsync((IEnumerable<WriteModel<T>>)entities, options)).IsAcknowledged;
        }

        public async Task<T> DeleteAsync(T entity)
         => await _collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);

        public async Task<T> DeleteAsync(int id)
            => await _collection.FindOneAndDeleteAsync(x => x.Id == id);

        public async Task<T> DeleteAsync(Expression<Func<T, bool>> predicate)
            => await _collection.FindOneAndDeleteAsync(predicate);

        public async Task<DeleteResult> DeleteRangeByIdsAsync(IEnumerable<int> ids)
        {
            var filter = Builders<T>.Filter.In("_id", ids);
            return await _collection.DeleteManyAsync(filter);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate = null) 
            => predicate == null
                ? _collection.AsQueryable()
                : _collection.AsQueryable().Where(predicate);

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
            => await _collection.Find(predicate).FirstOrDefaultAsync();

        public async Task<T> GetByIdAsync(int id)
            => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<T> UpdateAsync(int id, T entity)
         =>  await _collection.FindOneAndReplaceAsync(x => x.Id == id, entity);

        public async Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate)
         => await _collection.FindOneAndReplaceAsync(predicate, entity);
    }
}
