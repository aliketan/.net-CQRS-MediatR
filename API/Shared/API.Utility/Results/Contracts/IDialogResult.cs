namespace API.Utility.Results.Contracts
{
    using Utility.Exceptions;

    public interface IDialogResult
    {
        public string Status { get; }
        public string Response { get; }
        public DialogResultException Exception { get; }
    }
}
