using MediatR;

namespace API.Business.Features.CQRS.Handlers.Product
{
    using Business.Features.CQRS.Commands.Product;
    using Persistence.Data;
    using System.Threading;

    public class DeleteProductCommandHandler : BaseCommandHandler, IRequestHandler<DeleteProductCommand, bool>
    {
        #region Constructor
        public DeleteProductCommandHandler(
            IUnitOfWork uow):base(uow)
        {   

        }
        #endregion

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _uow.Product.DeleteByIdAsync(request.Id);
            return true;
        }
    }
}
