namespace API.Utility.Exceptions
{
    [Serializable]
    public class DialogResultException:Exception
    {
        public DialogResultException() : base(Localization.Exception.Lang.default_exception_message)
        { }

        public DialogResultException(string message) : base(message)
        { }
    }
}
