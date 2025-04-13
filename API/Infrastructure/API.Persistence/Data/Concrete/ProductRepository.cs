using MongoDB.Driver;

namespace API.Persistence.Data.Concrete
{
    using Contracts;
    using Model.Entities;
    using Repository.MongoDb.Concrete;

    public class ProductRepository(
        IMongoDatabase database) : MongoRepository<Product>(database), IProductRepository {}
}
