using AutoMapper;
using MediatR;

namespace API.Business.Features.CQRS.Handlers.Product
{
    using Features.CQRS.Queries.Product;
    using Features.CQRS.Results.Product;
    using Persistence.Data;

    public class GetProductByIdQueryHandler : BaseCommandHandler, IRequestHandler<GetProductByIdQuery, GetProductQueryResult>
    {
        private readonly IMapper _mapper;

        #region Constructor
        public GetProductByIdQueryHandler(
            IUnitOfWork uow,
            IMapper mapper
            ):base(uow)
        {
            _mapper = mapper;
        }
        #endregion

        public async Task<GetProductQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _uow.Product.GetByIdAsync(request.Id);
            var value = _mapper.Map<GetProductQueryResult>(data);
            return value;
        }
    }
}
