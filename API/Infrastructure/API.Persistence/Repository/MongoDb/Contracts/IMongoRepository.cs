namespace API.Persistence.Repository.MongoDb.Contracts
{
    using Model.Contracts;

    public interface IMongoRepository<T> where T : class, IEntity, new() { }
}
