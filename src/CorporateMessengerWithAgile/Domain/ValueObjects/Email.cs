using Domain.Result;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.ValueObjects
{
    [ComplexType]
    public class Email : BaseValueObject<string>
    {
        public const int MAX_LENGTH = 50;
        public const int MIN_LENGTH = 6;
        public const int FIRST_PART_MIN_LENGTH = 1;
        public const int SECOND_PART_MIN_LENGTH = 1;
        public const string DEFAULT_VALUE = "Email@DEFAULT_VALUE";

        internal Email() : base(DEFAULT_VALUE) { }
        private Email(string value) : base(value) { }

        public static Result<Email> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return DomainErrors.EmailError.Empty;
            if (value.Length > MAX_LENGTH) return DomainErrors.EmailError.TooLong;
            if (value.Length < MIN_LENGTH) return DomainErrors.EmailError.TooShort;

            if (!IsValidFormat(value)) return DomainErrors.EmailError.InvalidFormat;

            return new Email(value);
        }

        /// <summary>
        /// Проверка формата и размера левых и правых частей по разделителю '@'
        /// </summary>
        public static bool IsValidFormat(string email)
        {
            string[] split = email.Split('@');
            return
                split.Length == 2 &&
                split[0].Length >= FIRST_PART_MIN_LENGTH &&
                split[1].Length >= SECOND_PART_MIN_LENGTH;
        }
    }
}
