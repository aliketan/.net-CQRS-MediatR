using FluentValidation;

namespace API.Business.Validations.Category
{
    using Features.CQRS.Commands.Category;
    using Contracts;
    using Enums.ComplexTypes;

    public class UpdateCategoryCommandValidation : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidation(IMessageProvider provider)
        {
            RuleFor(r => r.Id).NotEmpty().WithMessage(x => provider.GetMessage(ValidationMessageKeys.GreaterThanZero, nameof(x.Id)));
        }
    }
}
