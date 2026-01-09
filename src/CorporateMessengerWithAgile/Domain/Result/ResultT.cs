using Domain.Result.CustomErrors;
using System.Text.Json.Serialization;

namespace Domain.Result
{
    [JsonConverter(typeof(ResultConverterFactory))]
    public class Result<T> : Result
    {
        private readonly T? _value;
        public T Value
        {
            get
            {
                if (IsFailure) throw new Exception("Result.CannotAccessValueOnFailure. Не возможно получить доступ к свойству Value для неудачного результата.");
                return _value!;
            }
        }

        protected internal Result(bool isSuccess, Error error, T? value) : base(isSuccess, error)
        {
            _value = value;
        }

        public T Check()
        {
            if (IsFailure) throw new Exception("");
            return Value;
        }

        public static implicit operator Result<T>(T value) => Success(value);
        public static implicit operator T(Result<T> result) => result.Check();
        public static implicit operator Result<T>(Error error) => Failure<T>(error);
    }
}