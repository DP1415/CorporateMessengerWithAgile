namespace Domain.Result
{
    public class Error(string code, string message)
    {
        /// <summary>
        /// Код ошибки.
        /// </summary>
        public string Code { get; } = code;
        public string Message { get; } = message;
    }
}
