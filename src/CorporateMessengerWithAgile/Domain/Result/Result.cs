namespace Domain.Result
{
    public record Result
    {
        public bool IsSuccess { get; init; }
        public bool IsFailure => !IsSuccess;

        private CustomException? _exception;
        public CustomException Exception
        {
            get
            {
                if (IsFailure) throw new InvalidOperationException();
                return _exception!;
            }
            init => _exception = value;
        }

        protected internal Result(bool isSuccess, CustomException error)
        {
            IsSuccess = isSuccess;
            Exception = error;
        }

        public static Result Success() => new(true, null!);
        public static Result<T> Success<T>(T value) => new(true, null!, value);
        public static Result Failure(CustomException exception) => new(false, exception);
        public static Result<T> Failure<T>(CustomException exception) => new(false, exception, default!);

        public static implicit operator Result(CustomException exception) => Failure(exception);
        public static implicit operator CustomException(Result result) => result.Exception;
    }
}