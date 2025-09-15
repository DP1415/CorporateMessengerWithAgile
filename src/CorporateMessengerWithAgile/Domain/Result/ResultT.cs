namespace Domain.Result
{
    public class Result<T> : Result
    {
        private T? _value;
        public T Value
        {
            get
            {
                if (IsFailure) throw new InvalidOperationException();
                return _value!;
            }
        }

        protected internal Result(bool isSuccess, CustomException exception, T? value)
            : base(isSuccess, exception)
        {
            _value = value;
        }

        public T Check()
        {
            if (IsFailure) throw Exception;
            return Value;
        }

        public static implicit operator Result<T>(T value) => Success(value);
        public static implicit operator T(Result<T> result) => result.Check();
        public static implicit operator Result<T>(CustomException exception) => Failure<T>(exception);
    }
}