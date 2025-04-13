namespace API.Business.Features.CQRS.Handlers
{
    using Persistence.Data;

    public abstract class BaseCommandHandler
    {
        protected readonly IUnitOfWork _uow;

        protected BaseCommandHandler(
            IUnitOfWork uow)
        {
            _uow = uow;
        }
    }
}
