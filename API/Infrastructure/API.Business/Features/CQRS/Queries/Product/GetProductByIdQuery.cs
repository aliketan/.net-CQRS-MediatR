using MediatR;

namespace API.Business.Features.CQRS.Queries.Product
{
    using Results.Product;

    public class GetProductByIdQuery(string id) : IRequest<GetProductQueryResult>
    {
        public string Id { get; set; } = id;
    }
}
