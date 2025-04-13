namespace API.Business.Validations.Concrete
{
    using Enums.ComplexTypes;
    using Contracts;

    public class MessageProvider : IMessageProvider
    {
        private readonly Dictionary<ValidationMessageKeys, string> _messages = new Dictionary<ValidationMessageKeys, string>
        {
            { ValidationMessageKeys.RequiredProperty, Localization.Validation.Lang.required_field },
            { ValidationMessageKeys.GreaterThanZero, Localization.Validation.Lang.greater_than_zero }
        };

        public string GetMessage(ValidationMessageKeys errorKey, string field) => _messages.TryGetValue(errorKey, out string message) ? string.Format(message, field) : null;
    }
}
