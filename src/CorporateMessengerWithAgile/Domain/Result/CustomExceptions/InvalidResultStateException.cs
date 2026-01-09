namespace Domain.Result.CustomExceptions
{
    public class InvalidResultStateException(string code, string message) : Error(code, message)
    {
        public static InvalidResultStateException CannotAccessValueOnFailure()
            => new("Result.CannotAccessValueOnFailure", "Не возможно получить доступ к свойству Value для неудачного результата.");
        public static InvalidResultStateException CannotAccessExceptionOnSuccess()
            => new("Result.CannotAccessExceptionOnSuccess", "Не возможно получить доступ к свойству Exception при успешном результате.");
    }
}
