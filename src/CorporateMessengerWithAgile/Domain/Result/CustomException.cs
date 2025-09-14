namespace Domain.Result
{
    public abstract class CustomException(string message) : Exception(message)
    {
    }
}
