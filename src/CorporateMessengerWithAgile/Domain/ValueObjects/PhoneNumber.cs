using Domain.Result;
using Domain.Result.CustomExceptions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    [ComplexType]
    public class PhoneNumber : BaseValueObject<string>
    {
        public const int MAX_LENGTH = 15;
        public const int MIN_LENGTH = 8;
        public const string DEFAULT_VALUE = "PhoneNumber DEFAULT_VALUE";

        internal PhoneNumber() : base(DEFAULT_VALUE) { }
        private PhoneNumber(string phoneNumber) : base(phoneNumber) { }

        /// <summary>
        /// Создание нового экземпляра <see cref="PhoneNumber"/> с проверкой входящих значений
        /// </summary>
        /// <param name="phoneNumber">Строка с номером телефона</param>
        public static Result<PhoneNumber> Create(string? phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber)) return CreateDefault();
            string cleanedNumber = Regex.Replace(phoneNumber, @"[^0-9+]", "");
            if (string.IsNullOrWhiteSpace(cleanedNumber)) return DomainException.PhoneNumberExp.Empty;
            if (cleanedNumber.Length > MAX_LENGTH) return DomainException.PhoneNumberExp.TooLong;
            if (cleanedNumber.Length < MIN_LENGTH) return DomainException.PhoneNumberExp.TooShort;
            return new PhoneNumber(cleanedNumber);
        }
        public static PhoneNumber CreateDefault() { return new PhoneNumber(); }
    }
}
