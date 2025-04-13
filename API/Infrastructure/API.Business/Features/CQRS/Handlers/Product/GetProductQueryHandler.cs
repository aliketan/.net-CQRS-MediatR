using AutoMapper;
using MediatR;

namespace API.Business.Features.CQRS.Handlers.Product
{
    using Features.CQRS.Queries.Product;
    using Features.CQRS.Results.Product;
    using Persistence.Data;

    public class GetProductQueryHandler : BaseCommandHandler, IRequestHandler<GetProductQuery, List<GetProductQueryResult>>
    {
        private readonly IMapper _mapper;

        #region Constructor
        public GetProductQueryHandler(
            IUnitOfWork uow,
            IMapper mapper
            ):base(uow)
        {
            _mapper = mapper;
        }
        #endregion

        public async Task<List<GetProductQueryResult>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var data = await _uow.Product.GetAllAsync();
            var values = _mapper.Map<List<GetProductQueryResult>>(data);
            return values;
        }
    }
}
