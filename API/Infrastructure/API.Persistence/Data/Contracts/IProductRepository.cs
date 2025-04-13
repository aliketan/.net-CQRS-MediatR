namespace API.Persistence.Data.Contracts
{
    using Model.Entities;
    using Repository.MongoDb.Contracts;

    public interface IProductRepository : IMongoEntityRepository<Product>
    {
    }
}
