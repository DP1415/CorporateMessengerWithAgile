namespace Domain.Result.CustomExceptions
{
    public class InvalidResultStateException(string message) : CustomException(message)
    {
        public static InvalidResultStateException CannotAccessValueOnFailure()
            => new("Не возможно получить доступ к свойству Value для неудачного результата.");
        public static InvalidResultStateException CannotAccessExceptionOnSuccess()
            => new("Не возможно получить доступ к свойству Exception при успешном результате.");
    }
}
