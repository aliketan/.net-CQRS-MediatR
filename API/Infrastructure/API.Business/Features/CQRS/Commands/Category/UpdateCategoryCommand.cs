using MediatR;

namespace API.Business.Features.CQRS.Commands.Category
{
    public class UpdateCategoryCommand:IRequest<bool>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
