using MediatR;

namespace API.Business.Features.CQRS.Handlers.Category
{
    using Business.Features.CQRS.Commands.Category;
    using Persistence.Data;
    using System.Threading;

    public class DeleteCategoryCommandHandler : BaseCommandHandler, IRequestHandler<DeleteCategoryCommand, bool>
    {
        #region Constructor
        public DeleteCategoryCommandHandler(
            IUnitOfWork uow):base(uow)
        {   

        }
        #endregion

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _uow.Category.DeleteByIdAsync(request.Id);
            return true;
        }
    }
}
