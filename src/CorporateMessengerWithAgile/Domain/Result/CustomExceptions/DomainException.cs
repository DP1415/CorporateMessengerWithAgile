namespace Domain.Result.CustomExceptions
{
    public class DomainException
    {
        public class EmailExp
        {
            public static EmptyException Empty => new();
            public class EmptyException() : Error
                ("Email.Empty", "Пустое поле");

            public static TooLongException TooLong => new();
            public class TooLongException() : Error
                ("Email.TooLong", $"Поле слишком длинное. Максимальная длина {Domain.ValueObjects.Email.MAX_LENGTH} символов");

            public static TooShortException TooShort => new();
            public class TooShortException() : Error
                ("Email.TooShort", $"Поле слишком короткое. Минимальная длина {Domain.ValueObjects.Email.MIN_LENGTH} символа");

            public static InvalidFormatException InvalidFormat => new();
            public class InvalidFormatException() : Error
                ("Email.InvalidFormat", "Поле имеет неправильный формат. Верный формат: example@mail.com");

            public static AlreadySetException AlreadySet => new();
            public class AlreadySetException() : Error
                ("Email.AlreadySet", "Значение совпадает с предыдущим");
        }
        public class PasswordHashedExp
        {

            public static EmptyException Empty => new();
            public class EmptyException() : Error
                ("PasswordHashed.Empty", "Пустое поле");

            public static TooLongException TooLong => new();
            public class TooLongException() : Error(
                "PasswordHashed.TooLong",
                $"Поле слишком длинное. Максимальная длина {Domain.ValueObjects.PasswordHashed.MAX_LENGTH} символов");

            public static TooShortException TooShort => new();
            public class TooShortException() : Error(
                "PasswordHashed.TooShort",
                $"Поле слишком короткое. Минимальная длина {Domain.ValueObjects.PasswordHashed.MIN_LENGTH} символа");

            public static AlreadySetException AlreadySet => new();
            public class AlreadySetException() : Error(
                "PasswordHashed.AlreadySet",
                "Значение совпадает с предыдущим");
        }
        public class PhoneNumberExp
        {
            public static EmptyException Empty => new();
            public class EmptyException() : Error
                ("PhoneNumber.Empty", "Телефон пуст");

            public static TooLongException TooLong => new();
            public class TooLongException() : Error
                ("PhoneNumber.TooLong", "Телефон слишком длинный");

            public static TooShortException TooShort => new();
            public class TooShortException() : Error
                ("PhoneNumber.TooShort", "Телефон слишком короткий");

            public static InvalidFormatException InvalidFormat => new();
            public class InvalidFormatException() : Error
                ("PhoneNumber.InvalidFormat", "Телефон имеет неверный формат или размер");

            public static AlreadyVerifiedException AlreadyVerified => new();
            public class AlreadyVerifiedException() : Error
                ("PhoneNumber.AlreadyVerified", "Телефон уже подтвержден");

            public static AlreadySetException AlreadySet => new();
            public class AlreadySetException() : Error
                ("PhoneNumber.AlreadySet", "Значение совпадает с предыдущим");
        }
        public static class TextExp
        {
            public static EmptyException Empty => new();
            public class EmptyException() : Error
                ("Text.Empty", "Содержание пусто");

            public static TooLongException TooLong => new();
            public class TooLongException() : Error
                ("Text.TooLong", "Содержание слишком длинное");

            public static AlreadySetException AlreadySet => new();
            public class AlreadySetException() : Error
                ("Text.AlreadySet", "Значение совпадает с предыдущим");
        }
        public static class TitleExp
        {
            public static EmptyException Empty => new();
            public class EmptyException() : Error
                ("Title.Empty", "Название пусто");

            public static TooLongException TooLong => new();
            public class TooLongException() : Error
                ("Title.TooLong", "Название слишком длинное");

            public static AlreadySetException AlreadySet => new();
            public class AlreadySetException() : Error
                ("Title.AlreadySet", "Значение совпадает с предыдущим");
        }
        public static class UsernameExp
        {
            public static EmptyException Empty => new();
            public class EmptyException() : Error
                ("Username.Empty", "Пустое поле");

            public static TooLongException TooLong => new();
            public class TooLongException() : Error
                ("Username.TooLong", $"Поле слишком длинное. Максимальная длина {Domain.ValueObjects.Username.MAX_LENGTH} символов");

            public static TooShortException TooShort => new();
            public class TooShortException() : Error
                ("Username.TooShort", $"Поле слишком короткое. Минимальная длина {Domain.ValueObjects.Username.MIN_LENGTH} символа");

            public static AlreadySetException AlreadySet => new();
            public class AlreadySetException() : Error
                ("Username.AlreadySet", "Имя пользователя совпадает с предыдущим");
        }
    }
}