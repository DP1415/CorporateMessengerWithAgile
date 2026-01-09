using Domain.Result;
using Domain.Result.CustomExceptions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace Domain.ValueObjects
{
    [ComplexType]
    public class PasswordHashed : BaseValueObject<string>
    {
        public const int MAX_LENGTH = 100;
        public const int MIN_LENGTH = 8;
        public const string DEFAULT_VALUE = "PasswordHashed DEFAULT_VALUE";

        internal PasswordHashed() : base(DEFAULT_VALUE) { }
        private PasswordHashed(string value) : base(value) { }

        public static Result<PasswordHashed> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return DomainErrors.PasswordHashedError.Empty;
            if (value.Length > MAX_LENGTH) return DomainErrors.PasswordHashedError.TooLong;
            if (value.Length < MIN_LENGTH) return DomainErrors.PasswordHashedError.TooShort;
            string hash = HashPassword(value);
            return new PasswordHashed(hash);
        }

        /// <summary>
        /// Метод хеширования пароля
        /// </summary>
        private static string HashPassword(string password)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2")); // Преобразуем байты в hex-строку
            }
            return builder.ToString();
        }
    }
}
