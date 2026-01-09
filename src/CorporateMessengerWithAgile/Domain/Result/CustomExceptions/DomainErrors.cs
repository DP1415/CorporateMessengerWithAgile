namespace Domain.Result.CustomExceptions
{
    public class DomainErrors
    {
        public static class EmailError
        {
            public static EmailEmpty Empty => new();
            public class EmailEmpty() : Error("Email.Empty", "Email пуст");

            public static EmailTooLong TooLong => new();
            public class EmailTooLong() : Error(
                "Email.TooLong",
                $"Email слишком длинный. Максимальная длина {Domain.ValueObjects.Email.MAX_LENGTH} символов");

            public static EmailTooShort TooShort => new();
            public class EmailTooShort() : Error(
                "Email.TooShort",
                $"Email слишком короткий. Минимальная длина {Domain.ValueObjects.Email.MIN_LENGTH} символа");

            public static EmailInvalidFormat InvalidFormat => new();
            public class EmailInvalidFormat() : Error("Email.InvalidFormat", "Email имеет неправильный формат. Верный формат: example@mail.com");

            public static EmailAlreadySet AlreadySet => new();
            public class EmailAlreadySet() : Error("Email.AlreadySet", "Email совпадает с предыдущим значением");
        }

        public static class PasswordHashedError
        {
            public static PasswordHashedEmpty Empty => new();
            public class PasswordHashedEmpty() : Error("PasswordHashed.Empty", "Пароль пуст");

            public static PasswordHashedTooLong TooLong => new();
            public class PasswordHashedTooLong() : Error(
                "PasswordHashed.TooLong", 
                $"Пароль слишком длинный. Максимальная длина {Domain.ValueObjects.PasswordHashed.MAX_LENGTH} символов");

            public static PasswordHashedTooShort TooShort => new();
            public class PasswordHashedTooShort() : Error(
                "PasswordHashed.TooShort", 
                $"Пароль слишком короткий. Минимальная длина {Domain.ValueObjects.PasswordHashed.MIN_LENGTH} символа");

            public static PasswordHashedAlreadySet AlreadySet => new();
            public class PasswordHashedAlreadySet() : Error("PasswordHashed.AlreadySet", "Пароль совпадает с предыдущим значением");
        }

        public static class PhoneNumberError
        {
            public static PhoneNumberEmpty Empty => new();
            public class PhoneNumberEmpty() : Error("PhoneNumber.Empty", "Телефон пуст");

            public static PhoneNumberTooLong TooLong => new();
            public class PhoneNumberTooLong() : Error(
                "PhoneNumber.TooLong", 
                $"Телефон слишком длинный. Максимальная длина {Domain.ValueObjects.PhoneNumber.MAX_LENGTH} символов");

            public static PhoneNumberTooShort TooShort => new();
            public class PhoneNumberTooShort() : Error(
                "PhoneNumber.TooShort", 
                $"Телефон слишком короткий. Минимальная длина {Domain.ValueObjects.PhoneNumber.MIN_LENGTH} символов");

            public static PhoneNumberInvalidFormat InvalidFormat => new();
            public class PhoneNumberInvalidFormat() : Error("PhoneNumber.InvalidFormat", "Телефон имеет неверный формат или размер");

            public static PhoneNumberAlreadyVerified AlreadyVerified => new();
            public class PhoneNumberAlreadyVerified() : Error("PhoneNumber.AlreadyVerified", "Телефон уже подтвержден");

            public static PhoneNumberAlreadySet AlreadySet => new();
            public class PhoneNumberAlreadySet() : Error("PhoneNumber.AlreadySet", "Телефон совпадает с предыдущим значением");
        }

        public static class TextError
        {
            public static TextEmpty Empty => new();
            public class TextEmpty() : Error("Text.Empty", "Текст пуст");

            public static TextTooLong TooLong => new();
            public class TextTooLong() : Error(
                "Text.TooLong", 
                $"Текст слишком длинный. Максимальная длина {Domain.ValueObjects.Text.MAX_LENGTH} символов");

            public static TextAlreadySet AlreadySet => new();
            public class TextAlreadySet() : Error("Text.AlreadySet", "Текст совпадает с предыдущим значением");
        }

        public static class TitleError
        {
            public static TitleEmpty Empty => new();
            public class TitleEmpty() : Error("Title.Empty", "Название пусто");

            public static TitleTooLong TooLong => new();
            public class TitleTooLong() : Error(
                "Title.TooLong", 
                $"Название слишком длинное. Максимальная длина {Domain.ValueObjects.Title.MAX_LENGTH} символов");

            public static TitleAlreadySet AlreadySet => new();
            public class TitleAlreadySet() : Error("Title.AlreadySet", "Название совпадает с предыдущим значением");
        }

        public static class UsernameError
        {
            public static UsernameEmpty Empty => new();
            public class UsernameEmpty() : Error("Username.Empty", "Имя пользователя пусто");

            public static UsernameTooLong TooLong => new();
            public class UsernameTooLong() : Error(
                "Username.TooLong", 
                $"Имя пользователя слишком длинное. Максимальная длина {Domain.ValueObjects.Username.MAX_LENGTH} символов");

            public static UsernameTooShort TooShort => new();
            public class UsernameTooShort() : Error(
                "Username.TooShort", 
                $"Имя пользователя слишком короткое. Минимальная длина {Domain.ValueObjects.Username.MIN_LENGTH} символа");

            public static UsernameAlreadySet AlreadySet => new();
            public class UsernameAlreadySet() : Error("Username.AlreadySet", "Имя пользователя совпадает с предыдущим значением");
        }
    }
}