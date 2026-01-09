using Domain.Result;
using Domain.Result.CustomExceptions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.ValueObjects
{
    [ComplexType]
    public class Username : BaseValueObject<string>
    {
        public const int MAX_LENGTH = 60;
        public const int MIN_LENGTH = 3;
        public const string DEFAULT_VALUE = "Username DEFAULT_VALUE";

        private Username() : base(DEFAULT_VALUE) { }
        private Username(string value) : base(value) { }

        public static Result<Username> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return DomainErrors.UsernameError.Empty;
            if (value.Length > MAX_LENGTH) return DomainErrors.UsernameError.TooLong;
            if (value.Length < MIN_LENGTH) return DomainErrors.UsernameError.TooShort;
            return new Username(value);
        }
    }
}
