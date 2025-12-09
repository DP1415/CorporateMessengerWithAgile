using Domain.Result.CustomExceptions;
using System.Text.Json.Serialization;

namespace Domain.Result
{
    [JsonConverter(typeof(ResultConverterFactory))]
    public class Result
    {
        public bool IsSuccess { get; init; }
        public bool IsFailure => !IsSuccess;

        private readonly Exception? _exception;
        public Exception Exception
        {
            get
            {
                if (IsSuccess) throw InvalidResultStateException.CannotAccessExceptionOnSuccess();
                return _exception!;
            }
        }

        protected internal Result(bool isSuccess, Exception exception)
        {
            IsSuccess = isSuccess;
            _exception = exception;
        }

        public static Result Success() => new(true, null!);
        public static Result Failure(Exception exception) => new(false, exception);
        public static Result<T> Success<T>(T value) => new(true, null!, value);
        public static Result<T> Failure<T>(Exception exception) => new(false, exception, default!);

        public static implicit operator Result(Exception exception) => Failure(exception);
        public static implicit operator Exception(Result result) => result.Exception;
    }
}
