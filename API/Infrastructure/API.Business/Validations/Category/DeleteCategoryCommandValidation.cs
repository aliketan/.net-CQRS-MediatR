using FluentValidation;

namespace API.Business.Validations.Category
{
    using Features.CQRS.Commands.Category;
    using Contracts;
    using Enums.ComplexTypes;

    public class DeleteCategoryCommandValidation : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidation(IMessageProvider provider)
        {
            RuleFor(r => r.Id).NotEmpty().WithMessage(x => provider.GetMessage(ValidationMessageKeys.GreaterThanZero, nameof(x.Id)));
        }
    }
}
