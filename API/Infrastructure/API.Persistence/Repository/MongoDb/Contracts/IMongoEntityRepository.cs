using System.Linq.Expressions;

namespace API.Persistence.Repository.MongoDb.Contracts
{
    using Model.Contracts;

    public interface IMongoEntityRepository<T> where T : class, IEntity, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(string id);

        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteByIdAsync(string id);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        Task<bool> ExistsAsync(string id);
    }
}
