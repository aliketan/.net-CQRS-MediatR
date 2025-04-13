using MongoDB.Driver;

namespace API.Persistence.Data.Concrete
{
    using Contracts;
    using Model.Entities;
    using Persistence.Repository.MongoDb.Concrete;

    public class CategoryRepository(
        IMongoDatabase database) : MongoRepository<Category>(database), ICategoryRepository { }
}
