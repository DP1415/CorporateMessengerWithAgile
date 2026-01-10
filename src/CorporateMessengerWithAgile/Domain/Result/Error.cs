namespace Domain.Result
{
    public class Error(string code, string message, int statusCode)
    {
        public string Code { get; } = code;
        public string Message { get; } = message;
        public int StatusCode { get; } = statusCode;
    }
}
