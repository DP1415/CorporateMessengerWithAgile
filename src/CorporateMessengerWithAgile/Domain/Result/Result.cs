namespace Domain.Result
{
    public class Result
    {
        public bool IsSuccess { get; init; }
        public bool IsFailure => !IsSuccess;

        private CustomException? _exception;
        public CustomException Exception
        {
            get
            {
                if (IsSuccess) throw new InvalidOperationException();
                return _exception!;

            }
        }

        protected internal Result(bool isSuccess, CustomException exception)
        {
            IsSuccess = isSuccess;
            _exception = exception;
        }

        public static Result Success() => new(true, null!);
        public static Result Failure(CustomException exception) => new(false, exception);
        public static Result<T> Success<T>(T value) => new(true, null!, value);
        public static Result<T> Failure<T>(CustomException exception) => new(false, exception, default!);

        public static implicit operator Result(CustomException exception) => Failure(exception);
        public static implicit operator CustomException(Result result) => result.Exception;
    }
}
