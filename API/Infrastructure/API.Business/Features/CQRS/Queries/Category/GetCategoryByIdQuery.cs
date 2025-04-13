using MediatR;

namespace API.Business.Features.CQRS.Queries.Category
{
    using Results.Category;

    public class GetCategoryByIdQuery(string id) : IRequest<GetCategoryQueryResult>
    {
        public string Id { get; set; } = id;
    }
}
