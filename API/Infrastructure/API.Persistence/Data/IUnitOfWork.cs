namespace API.Persistence.Data
{
    using Contracts;

    public interface IUnitOfWork : IDisposable
    {
        public ICategoryRepository Category { get; } //_uow.Category

        public IProductRepository Product { get; } //_uow.Product
    }
}
