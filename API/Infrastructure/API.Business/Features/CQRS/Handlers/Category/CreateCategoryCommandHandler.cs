using AutoMapper;
using MediatR;

namespace API.Business.Features.CQRS.Handlers.Category
{
    using Business.Features.CQRS.Commands.Category;
    using Persistence.Data;
    using System.Threading;

    public class CreateCategoryCommandHandler: BaseCommandHandler, IRequestHandler<CreateCategoryCommand, bool>
    {
        private readonly IMapper _mapper;

        #region Constructor
        public CreateCategoryCommandHandler(
            IUnitOfWork uow, 
            IMapper mapper):base(uow)
        {   
            _mapper = mapper;
        }
        #endregion

        public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Model.Entities.Category>(request);
            await _uow.Category.AddAsync(entity);
            return true;
        }
       
    }
}
