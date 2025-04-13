using AutoMapper;
using MediatR;

namespace API.Business.Features.CQRS.Handlers.Product
{
    using Business.Features.CQRS.Commands.Product;
    using Persistence.Data;
    using System.Threading;

    public class UpdateAddressCommandHandler : BaseCommandHandler, IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IMapper _mapper;

        #region Constructor
        public UpdateAddressCommandHandler(
            IUnitOfWork uow, 
            IMapper mapper):base(uow)
        {
            _mapper = mapper;
        }
        #endregion

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Model.Entities.Product>(request);
            await _uow.Product.UpdateAsync(entity);
            return true;
        }
       
    }
}
