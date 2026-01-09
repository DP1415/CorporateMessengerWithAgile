using System.Text.Json.Serialization;

namespace Domain.Result
{
    [JsonConverter(typeof(ResultConverterFactory))]
    public class Result
    {
        public bool IsSuccess { get; init; }
        [JsonIgnore]
        public bool IsFailure => !IsSuccess;

        private readonly Error? _error;

        public Error Error
        {
            get
            {
                if (IsSuccess) throw new Exception("Result.CannotAccessExceptionOnSuccess. Не возможно получить доступ к свойству Exception при успешном результате.");
                return _error!;
            }
        }

        protected internal Result(bool isSuccess, Error error)
        {
            IsSuccess = isSuccess;
            _error = error;
        }

        public static Result Success() => new(true, null!);
        public static Result Failure(Error error) => new(false, error);
        public static Result<T> Success<T>(T value) => new(true, null!, value);
        public static Result<T> Failure<T>(Error error) => new(false, error, default!);

        public static implicit operator Result(Error error) => Failure(error);
        public static implicit operator Exception(Result result) => new(result.Error.Code);
    }
}
