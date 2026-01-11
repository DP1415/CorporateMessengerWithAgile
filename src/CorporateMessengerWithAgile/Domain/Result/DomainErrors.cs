using Microsoft.AspNetCore.Http;

namespace Domain.Result
{
    public class DomainErrors
    {
        public static class EmailError
        {
            public static EmailEmpty Empty => new();
            public record EmailEmpty() : Error("Email.Empty", "Email пуст", StatusCodes.Status400BadRequest);

            public static EmailTooLong TooLong => new();
            public record EmailTooLong() : Error(
                "Email.TooLong",
                $"Email слишком длинный. Максимальная длина {Domain.ValueObjects.Email.MAX_LENGTH} символов",
                StatusCodes.Status400BadRequest);

            public static EmailTooShort TooShort => new();
            public record EmailTooShort() : Error(
                "Email.TooShort",
                $"Email слишком короткий. Минимальная длина {ValueObjects.Email.MIN_LENGTH} символа",
                StatusCodes.Status400BadRequest);

            public static EmailInvalidFormat InvalidFormat => new();
            public record EmailInvalidFormat() : Error("Email.InvalidFormat", "Email имеет неправильный формат. Верный формат: example@mail.com", StatusCodes.Status400BadRequest);

            public static EmailAlreadySet AlreadySet => new();
            public record EmailAlreadySet() : Error("Email.AlreadySet", "Email совпадает с предыдущим значением", StatusCodes.Status409Conflict);
        }

        public static class PasswordHashedError
        {
            public static PasswordHashedEmpty Empty => new();
            public record PasswordHashedEmpty() : Error("PasswordHashed.Empty", "Пароль пуст", StatusCodes.Status400BadRequest);

            public static PasswordHashedTooLong TooLong => new();
            public record PasswordHashedTooLong() : Error(
                "PasswordHashed.TooLong",
                $"Пароль слишком длинный. Максимальная длина {ValueObjects.PasswordHashed.MAX_LENGTH} символов",
                StatusCodes.Status400BadRequest);

            public static PasswordHashedTooShort TooShort => new();
            public record PasswordHashedTooShort() : Error(
                "PasswordHashed.TooShort",
                $"Пароль слишком короткий. Минимальная длина {ValueObjects.PasswordHashed.MIN_LENGTH} символа",
                StatusCodes.Status400BadRequest);

            public static PasswordHashedAlreadySet AlreadySet => new();
            public record PasswordHashedAlreadySet() : Error("PasswordHashed.AlreadySet", "Пароль совпадает с предыдущим значением", StatusCodes.Status409Conflict);
        }

        public static class PhoneNumberError
        {
            public static PhoneNumberEmpty Empty => new();
            public record PhoneNumberEmpty() : Error("PhoneNumber.Empty", "Телефон пуст", StatusCodes.Status400BadRequest);

            public static PhoneNumberTooLong TooLong => new();
            public record PhoneNumberTooLong() : Error(
                "PhoneNumber.TooLong",
                $"Телефон слишком длинный. Максимальная длина {ValueObjects.PhoneNumber.MAX_LENGTH} символов",
                StatusCodes.Status400BadRequest);

            public static PhoneNumberTooShort TooShort => new();
            public record PhoneNumberTooShort() : Error(
                "PhoneNumber.TooShort",
                $"Телефон слишком короткий. Минимальная длина {ValueObjects.PhoneNumber.MIN_LENGTH} символов",
                StatusCodes.Status400BadRequest);

            public static PhoneNumberInvalidFormat InvalidFormat => new();
            public record PhoneNumberInvalidFormat() : Error("PhoneNumber.InvalidFormat", "Телефон имеет неверный формат или размер", StatusCodes.Status400BadRequest);

            public static PhoneNumberAlreadyVerified AlreadyVerified => new();
            public record PhoneNumberAlreadyVerified() : Error("PhoneNumber.AlreadyVerified", "Телефон уже подтвержден", StatusCodes.Status409Conflict);

            public static PhoneNumberAlreadySet AlreadySet => new();
            public record PhoneNumberAlreadySet() : Error("PhoneNumber.AlreadySet", "Телефон совпадает с предыдущим значением", StatusCodes.Status409Conflict);
        }

        public static class TextError
        {
            public static TextEmpty Empty => new();
            public record TextEmpty() : Error("Text.Empty", "Текст пуст", StatusCodes.Status400BadRequest);

            public static TextTooLong TooLong => new();
            public record TextTooLong() : Error(
                "Text.TooLong",
                $"Текст слишком длинный. Максимальная длина {ValueObjects.Text.MAX_LENGTH} символов",
                StatusCodes.Status400BadRequest);

            public static TextAlreadySet AlreadySet => new();
            public record TextAlreadySet() : Error("Text.AlreadySet", "Текст совпадает с предыдущим значением", StatusCodes.Status409Conflict);
        }

        public static class TitleError
        {
            public static TitleEmpty Empty => new();
            public record TitleEmpty() : Error("Title.Empty", "Название пусто", StatusCodes.Status400BadRequest);

            public static TitleTooLong TooLong => new();
            public record TitleTooLong() : Error(
                "Title.TooLong",
                $"Название слишком длинное. Максимальная длина {ValueObjects.Title.MAX_LENGTH} символов",
                StatusCodes.Status400BadRequest);

            public static TitleAlreadySet AlreadySet => new();
            public record TitleAlreadySet() : Error("Title.AlreadySet", "Название совпадает с предыдущим значением", StatusCodes.Status409Conflict);
        }

        public static class UsernameError
        {
            public static UsernameEmpty Empty => new();
            public record UsernameEmpty() : Error("Username.Empty", "Имя пользователя пусто", StatusCodes.Status400BadRequest);

            public static UsernameTooLong TooLong => new();
            public record UsernameTooLong() : Error(
                "Username.TooLong",
                $"Имя пользователя слишком длинное. Максимальная длина {ValueObjects.Username.MAX_LENGTH} символов",
                StatusCodes.Status400BadRequest);

            public static UsernameTooShort TooShort => new();
            public record UsernameTooShort() : Error(
                "Username.TooShort",
                $"Имя пользователя слишком короткое. Минимальная длина {ValueObjects.Username.MIN_LENGTH} символа",
                StatusCodes.Status400BadRequest);

            public static UsernameAlreadySet AlreadySet => new();
            public record UsernameAlreadySet() : Error("Username.AlreadySet", "Имя пользователя совпадает с предыдущим значением", StatusCodes.Status409Conflict);
        }
    }
}
