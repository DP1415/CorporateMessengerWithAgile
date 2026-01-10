using Microsoft.AspNetCore.Http;

namespace Domain.Result
{
    public class DomainErrors
    {
        public static class EmailError
        {
            public static EmailEmpty Empty => new();
            public class EmailEmpty() : Error("Email.Empty", "Email пуст", StatusCodes.Status400BadRequest);

            public static EmailTooLong TooLong => new();
            public class EmailTooLong() : Error(
                "Email.TooLong",
                $"Email слишком длинный. Максимальная длина {Domain.ValueObjects.Email.MAX_LENGTH} символов",
                StatusCodes.Status400BadRequest);

            public static EmailTooShort TooShort => new();
            public class EmailTooShort() : Error(
                "Email.TooShort",
                $"Email слишком короткий. Минимальная длина {ValueObjects.Email.MIN_LENGTH} символа",
                StatusCodes.Status400BadRequest);

            public static EmailInvalidFormat InvalidFormat => new();
            public class EmailInvalidFormat() : Error("Email.InvalidFormat", "Email имеет неправильный формат. Верный формат: example@mail.com", StatusCodes.Status400BadRequest);

            public static EmailAlreadySet AlreadySet => new();
            public class EmailAlreadySet() : Error("Email.AlreadySet", "Email совпадает с предыдущим значением", StatusCodes.Status409Conflict);
        }

        public static class PasswordHashedError
        {
            public static PasswordHashedEmpty Empty => new();
            public class PasswordHashedEmpty() : Error("PasswordHashed.Empty", "Пароль пуст", StatusCodes.Status400BadRequest);

            public static PasswordHashedTooLong TooLong => new();
            public class PasswordHashedTooLong() : Error(
                "PasswordHashed.TooLong",
                $"Пароль слишком длинный. Максимальная длина {ValueObjects.PasswordHashed.MAX_LENGTH} символов",
                StatusCodes.Status400BadRequest);

            public static PasswordHashedTooShort TooShort => new();
            public class PasswordHashedTooShort() : Error(
                "PasswordHashed.TooShort",
                $"Пароль слишком короткий. Минимальная длина {ValueObjects.PasswordHashed.MIN_LENGTH} символа",
                StatusCodes.Status400BadRequest);

            public static PasswordHashedAlreadySet AlreadySet => new();
            public class PasswordHashedAlreadySet() : Error("PasswordHashed.AlreadySet", "Пароль совпадает с предыдущим значением", StatusCodes.Status409Conflict);
        }

        public static class PhoneNumberError
        {
            public static PhoneNumberEmpty Empty => new();
            public class PhoneNumberEmpty() : Error("PhoneNumber.Empty", "Телефон пуст", StatusCodes.Status400BadRequest);

            public static PhoneNumberTooLong TooLong => new();
            public class PhoneNumberTooLong() : Error(
                "PhoneNumber.TooLong",
                $"Телефон слишком длинный. Максимальная длина {ValueObjects.PhoneNumber.MAX_LENGTH} символов",
                StatusCodes.Status400BadRequest);

            public static PhoneNumberTooShort TooShort => new();
            public class PhoneNumberTooShort() : Error(
                "PhoneNumber.TooShort",
                $"Телефон слишком короткий. Минимальная длина {ValueObjects.PhoneNumber.MIN_LENGTH} символов",
                StatusCodes.Status400BadRequest);

            public static PhoneNumberInvalidFormat InvalidFormat => new();
            public class PhoneNumberInvalidFormat() : Error("PhoneNumber.InvalidFormat", "Телефон имеет неверный формат или размер", StatusCodes.Status400BadRequest);

            public static PhoneNumberAlreadyVerified AlreadyVerified => new();
            public class PhoneNumberAlreadyVerified() : Error("PhoneNumber.AlreadyVerified", "Телефон уже подтвержден", StatusCodes.Status409Conflict);

            public static PhoneNumberAlreadySet AlreadySet => new();
            public class PhoneNumberAlreadySet() : Error("PhoneNumber.AlreadySet", "Телефон совпадает с предыдущим значением", StatusCodes.Status409Conflict);
        }

        public static class TextError
        {
            public static TextEmpty Empty => new();
            public class TextEmpty() : Error("Text.Empty", "Текст пуст", StatusCodes.Status400BadRequest);

            public static TextTooLong TooLong => new();
            public class TextTooLong() : Error(
                "Text.TooLong",
                $"Текст слишком длинный. Максимальная длина {ValueObjects.Text.MAX_LENGTH} символов",
                StatusCodes.Status400BadRequest);

            public static TextAlreadySet AlreadySet => new();
            public class TextAlreadySet() : Error("Text.AlreadySet", "Текст совпадает с предыдущим значением", StatusCodes.Status409Conflict);
        }

        public static class TitleError
        {
            public static TitleEmpty Empty => new();
            public class TitleEmpty() : Error("Title.Empty", "Название пусто", StatusCodes.Status400BadRequest);

            public static TitleTooLong TooLong => new();
            public class TitleTooLong() : Error(
                "Title.TooLong",
                $"Название слишком длинное. Максимальная длина {ValueObjects.Title.MAX_LENGTH} символов",
                StatusCodes.Status400BadRequest);

            public static TitleAlreadySet AlreadySet => new();
            public class TitleAlreadySet() : Error("Title.AlreadySet", "Название совпадает с предыдущим значением", StatusCodes.Status409Conflict);
        }

        public static class UsernameError
        {
            public static UsernameEmpty Empty => new();
            public class UsernameEmpty() : Error("Username.Empty", "Имя пользователя пусто", StatusCodes.Status400BadRequest);

            public static UsernameTooLong TooLong => new();
            public class UsernameTooLong() : Error(
                "Username.TooLong",
                $"Имя пользователя слишком длинное. Максимальная длина {ValueObjects.Username.MAX_LENGTH} символов",
                StatusCodes.Status400BadRequest);

            public static UsernameTooShort TooShort => new();
            public class UsernameTooShort() : Error(
                "Username.TooShort",
                $"Имя пользователя слишком короткое. Минимальная длина {ValueObjects.Username.MIN_LENGTH} символа",
                StatusCodes.Status400BadRequest);

            public static UsernameAlreadySet AlreadySet => new();
            public class UsernameAlreadySet() : Error("Username.AlreadySet", "Имя пользователя совпадает с предыдущим значением", StatusCodes.Status409Conflict);
        }
    }
}
