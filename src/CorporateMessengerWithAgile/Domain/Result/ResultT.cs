namespace Domain.Result
{
    public record Result<T> : Result
    {
        private T? _value;
        public T Value
        {
            get
            {
                if (IsFailure) throw new InvalidOperationException();
                return _value!;
            }
            init => _value = value;
        }

        protected internal Result(bool isSuccess, CustomException error, T value) : base(isSuccess, error)
        {
            Value = value;
        }

        public T Check()
        {
            if (IsFailure) throw Exception;
            return Value;
        }

        public static implicit operator Result<T>(T value) => Success(value);
        public static implicit operator Result<T>(CustomException exception) => Failure<T>(exception);
        public static implicit operator T(Result<T> result) => result.Check();
        public static implicit operator CustomException(Result<T> result) => result.Exception;
    }
}