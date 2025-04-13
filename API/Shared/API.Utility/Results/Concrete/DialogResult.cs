namespace API.Utility.Results.Concrete
{
    using Enums.ComplexTypes;
    using Contracts;
    using Exceptions;
    using Enums.Extenders;

    public class DialogResult:IDialogResult
    {
        public DialogResult(ResultStatus status)
        {
            Status = status.ToText();
        }

        public DialogResult(ResultStatus status, string response)
        {
            Status = status.ToText();
            Response = response;
        }

        public DialogResult(ResultStatus status, string response, DialogResultException exception)
        {
            Status = status.ToText();
            Response = response;
            Exception = exception;
        }

        public DialogResult(ResultStatus status, DialogResultException exception)
        {
            Status = status.ToText();
            Exception = exception;
        }

        public string Status { get; }

        public string Response { get; }

        public DialogResultException Exception { get; }
    }
}
