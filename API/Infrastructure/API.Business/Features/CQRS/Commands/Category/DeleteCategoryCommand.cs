using MediatR;

namespace API.Business.Features.CQRS.Commands.Category
{
    public class DeleteCategoryCommand(string id) : IRequest<bool>
    {
        public string Id { get; set; } = id;
    }
}
