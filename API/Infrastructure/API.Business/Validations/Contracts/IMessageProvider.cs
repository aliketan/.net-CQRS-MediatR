namespace API.Business.Validations.Contracts
{
    using Enums.ComplexTypes;

    public interface IMessageProvider
    {
        public string GetMessage(ValidationMessageKeys errorKey, string field);
    }
}
