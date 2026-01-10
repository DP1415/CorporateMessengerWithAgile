using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        protected internal Result(bool isSuccess, Error error, int statusCode, T? value) : base(isSuccess, error, statusCode)
        {
            _value = value;
        }

        public T Check()
        {
            if (IsFailure) throw new Exception("");
            return Value;
        }

        public static implicit operator Result<T>(T value) => Success(value, 200);
        public static implicit operator T(Result<T> result) => result.Check();
        public static implicit operator Result<T>(Error error) => Failure<T>(error);
    }
}