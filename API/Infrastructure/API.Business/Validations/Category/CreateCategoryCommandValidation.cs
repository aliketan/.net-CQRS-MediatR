using FluentValidation;

namespace API.Business.Validations.Category
{
    using Features.CQRS.Commands.Category;
    using Contracts;
    using Enums.ComplexTypes;

    public class CreateCategoryCommandValidation:AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidation(IMessageProvider provider)
        {
            RuleFor(r => r.Name).NotEmpty().WithMessage(x => provider.GetMessage(ValidationMessageKeys.RequiredProperty, nameof(x.Name)));
        }
    }
}
