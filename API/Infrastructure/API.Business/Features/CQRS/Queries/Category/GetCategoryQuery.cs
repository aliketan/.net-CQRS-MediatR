using MediatR;

namespace API.Business.Features.CQRS.Queries.Category
{
    using Results.Category;

    public class GetCategoryQuery:IRequest<List<GetCategoryQueryResult>>
    {

    }
}
