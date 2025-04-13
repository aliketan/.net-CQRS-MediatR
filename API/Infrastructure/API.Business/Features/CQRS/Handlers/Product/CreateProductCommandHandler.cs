using AutoMapper;
using MediatR;

namespace API.Business.Features.CQRS.Handlers.Product
{
    using Business.Features.CQRS.Commands.Product;
    using Persistence.Data;
    using System.Threading;

    public class CreateProductCommandHandler: BaseCommandHandler, IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IMapper _mapper;

        #region Constructor
        public CreateProductCommandHandler(
            IUnitOfWork uow, 
            IMapper mapper):base(uow)
        {   
            _mapper = mapper;
        }
        #endregion

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Model.Entities.Product>(request);
            await _uow.Product.AddAsync(entity);
            return true;
        }
       
    }
}
