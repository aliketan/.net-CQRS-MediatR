using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace API.Persistence.Data
{
    using Concrete;
    using Contracts;
    using Model.Configuration;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoDatabase _database;
        private bool _disposed = false;

        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;

        #region Constructor
        public UnitOfWork(IOptions<DatabaseSettings> options)
        {
            var client = new MongoClient(options.Value.MongoDb.ConnectionString);
            _database = client.GetDatabase(options.Value.MongoDb.DatabaseName);
        }
        #endregion

        public ICategoryRepository Category => _categoryRepository ??= new CategoryRepository(_database);
        public IProductRepository Product => _productRepository ??= new ProductRepository(_database);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                _disposed = true;
        }
    }
}
