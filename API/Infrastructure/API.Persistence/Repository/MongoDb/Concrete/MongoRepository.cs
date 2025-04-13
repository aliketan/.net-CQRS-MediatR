using MongoDB.Driver;
using System.Linq.Expressions;

namespace API.Persistence.Repository.MongoDb.Concrete
{
    using Model.Contracts;
    using Contracts;

    public class MongoRepository<T> : IMongoEntityRepository<T> where T : class, IEntity, new()
    {
        private readonly IMongoCollection<T> _collection;

        #region Constructor
        public MongoRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<T>(typeof(T).Name);
        }
        #endregion

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(q => q.Id == id).SingleOrDefaultAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _collection.InsertManyAsync(entities);
        }

        public async Task UpdateAsync(T entity)
        {
            await _collection.ReplaceOneAsync(q => q.Id == entity.Id, entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await _collection.DeleteOneAsync(q => q.Id == entity.Id);
        }

        public async Task DeleteByIdAsync(string id)
        {
            await _collection.DeleteOneAsync(q => q.Id == id);
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            var filter = Builders<T>.Filter.In(q => q.Id, entities.Select(s => s.Id));
            await _collection.DeleteManyAsync(filter);
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _collection.Find(q => q.Id == id).AnyAsync();
        }
    }
}
