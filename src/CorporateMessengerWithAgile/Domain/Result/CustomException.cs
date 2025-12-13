namespace Domain.Result
{
    public abstract class CustomException(string code, string message) : Exception($"& {code} {message}")
    {
        /// <summary>
        /// Код ошибки.
        /// </summary>
        public string Code { get; } = code;
    }
}
