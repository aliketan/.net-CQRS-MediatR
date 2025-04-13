using AutoMapper;
using MediatR;

namespace API.Business.Features.CQRS.Handlers.Category
{
    using Features.CQRS.Queries.Category;
    using Features.CQRS.Results.Category;
    using Persistence.Data;

    public class GetCategoryByIdQueryHandler : BaseCommandHandler, IRequestHandler<GetCategoryByIdQuery, GetCategoryQueryResult>
    {
        private readonly IMapper _mapper;

        #region Constructor
        public GetCategoryByIdQueryHandler(
            IUnitOfWork uow,
            IMapper mapper
            ):base(uow)
        {
            _mapper = mapper;
        }
        #endregion

        public async Task<GetCategoryQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _uow.Category.GetByIdAsync(request.Id);
            var value = _mapper.Map<GetCategoryQueryResult>(data);
            return value;
        }
    }
}
