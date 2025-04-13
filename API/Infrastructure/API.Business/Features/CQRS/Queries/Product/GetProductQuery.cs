using MediatR;

namespace API.Business.Features.CQRS.Queries.Product
{
    using Results.Product;

    public class GetProductQuery:IRequest<List<GetProductQueryResult>>
    {

    }
}
