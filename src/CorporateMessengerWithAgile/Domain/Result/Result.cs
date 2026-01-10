using System.Runtime.CompilerServices;
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

        public int StatusCode { get; protected set; }

        protected internal Result(bool isSuccess, Error error, int statusCode)
        {
            IsSuccess = isSuccess;
            _error = error;
            StatusCode = statusCode;
        }

        public static Result Success(int statusCode) => new(true, null!, statusCode);
        public static Result Failure(Error error) => new(false, error, error.StatusCode);
        public static Result<T> Success<T>(T value, int statusCode) => new(true, null!, statusCode, value);
        public static Result<T> Failure<T>(Error error) => new(false, error, error.StatusCode, default!);

        public static implicit operator Result(Error error) => Failure(error);

        public Result SetStatusCode(int statusCode)
        {
            StatusCode = statusCode;
            return this;
        }
    }
}
