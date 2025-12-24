using Domain.Common;
using Domain.Result;
using Domain.Result.CustomExceptions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.ValueObjects
{
    [ComplexType]
    public class Title : ValueObject<string>
    {
        public const int MAX_LENGTH = 100;
        public const string DEFAULT_VALUE = "Title DEFAULT_VALUE";

        internal Title() : base(DEFAULT_VALUE) { }
        private Title(string value) : base(value) { }

        /// <summary>
        /// Создание экземпляра <see cref="Title"/>  с проверкой входящих значений
        /// </summary>
        /// <param name="title">Строка с названием</param>
        /// <returns>Новый экземпляр <see cref="Title"/></returns>
        public static Result<Title> Create(string? title)
        {
            if (string.IsNullOrWhiteSpace(title)) return CreateDefault();
            if (title.Length > MAX_LENGTH) return DomainException.TitleExp.TooLong;
            return new Title(title);
        }
        public static Title CreateDefault() { return new Title(); }
    }
}
