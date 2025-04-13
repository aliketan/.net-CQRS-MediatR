using AutoMapper;
using MediatR;

namespace API.Business.Features.CQRS.Handlers.Category
{
    using Features.CQRS.Queries.Category;
    using Features.CQRS.Results.Category;
    using Persistence.Data;

    public class GetCategoryQueryHandler : BaseCommandHandler, IRequestHandler<GetCategoryQuery, List<GetCategoryQueryResult>>
    {
        private readonly IMapper _mapper;

        #region Constructor
        public GetCategoryQueryHandler(
            IUnitOfWork uow,
            IMapper mapper
            ):base(uow)
        {
            _mapper = mapper;
        }
        #endregion

        public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var data = await _uow.Category.GetAllAsync();
            var values = _mapper.Map<List<GetCategoryQueryResult>>(data);
            return values;
        }
    }
}
