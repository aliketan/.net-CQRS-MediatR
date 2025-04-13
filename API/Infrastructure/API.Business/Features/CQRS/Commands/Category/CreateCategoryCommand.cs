using MediatR;

namespace API.Business.Features.CQRS.Commands.Category
{
    public class CreateCategoryCommand:IRequest<bool>
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
