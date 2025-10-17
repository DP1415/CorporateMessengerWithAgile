using Domain.Common;
using Domain.Result;
using Domain.Result.CustomExceptions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.ValueObjects
{
    [ComplexType]
    public class Username : ValueObject<string>
    {
        public const int MAX_LENGTH = 60;
        public const int MIN_LENGTH = 3;
        public const string DEFAULT_VALUE = "Username DEFAULT_VALUE";

        private Username() : base(DEFAULT_VALUE) { }
        private Username(string value) : base(value) { }

        public static Result<Username> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return DomainException.Username.Empty;
            if (value.Length > MAX_LENGTH) return DomainException.Username.TooLong;
            if (value.Length < MIN_LENGTH) return DomainException.Username.TooShort;
            return new Username(value);
        }
    }
}
