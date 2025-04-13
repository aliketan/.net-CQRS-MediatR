using AutoMapper;
using MediatR;

namespace API.Business.Features.CQRS.Handlers.Category
{
    using Business.Features.CQRS.Commands.Category;
    using Persistence.Data;
    using System.Threading;

    public class UpdateCategoryCommandHandler : BaseCommandHandler, IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly IMapper _mapper;

        #region Constructor
        public UpdateCategoryCommandHandler(
            IUnitOfWork uow, 
            IMapper mapper):base(uow)
        {
            _mapper = mapper;
        }
        #endregion

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Model.Entities.Category>(request);
            await _uow.Category.UpdateAsync(entity);
            return true;
        }
       
    }
}
