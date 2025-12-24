using Domain.Common;
using Domain.Result;
using Domain.Result.CustomExceptions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.ValueObjects
{
    [ComplexType]
    public class Text : BaseValueObject<string>
    {
        public const int MAX_LENGTH = 5000;
        public const string DEFAULT_VALUE = "Text DEFAULT_VALUE";

        internal Text() : base(DEFAULT_VALUE) { }
        private Text(string value) : base(value) { }

        /// <summary>
        /// Создание нового экземпляра <see cref="Text"/> с проверкой входящих значений
        /// </summary>
        /// <param name="stringText">Строка с текстом</param>
        public static Result<Text> Create(string? stringText)
        {
            if (string.IsNullOrWhiteSpace(stringText)) return CreateDefault();
            if (stringText.Length > MAX_LENGTH) return DomainException.TextExp.TooLong;
            return new Text(stringText);
        }
        public static Text CreateDefault() { return new Text(); }
    }
}
