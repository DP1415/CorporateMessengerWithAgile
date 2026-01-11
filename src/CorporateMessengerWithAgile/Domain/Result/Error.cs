namespace Domain.Result
{
    public record Error(
        string Code,
        string Message,
        int StatusCode
        );
}
