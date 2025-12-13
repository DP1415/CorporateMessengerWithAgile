namespace Domain.Result.CustomExceptions
{
    public class DomainException
    {
        public class EmailExp
        {
            public static EmptyException Empty => new();
            public class EmptyException() : CustomException
                ("Email.Empty", "Пустое поле");

            public static TooLongException TooLong => new();
            public class TooLongException() : CustomException
                ("Email.TooLong", $"Поле слишком длинное. Максимальная длина {Domain.ValueObjects.Email.MAX_LENGTH} символов");

            public static TooShortException TooShort => new();
            public class TooShortException() : CustomException
                ("Email.TooShort", $"Поле слишком короткое. Минимальная длина {Domain.ValueObjects.Email.MIN_LENGTH} символа");

            public static InvalidFormatException InvalidFormat => new();
            public class InvalidFormatException() : CustomException
                ("Email.InvalidFormat", "Поле имеет неправильный формат. Верный формат: example@mail.com");

            public static AlreadySetException AlreadySet => new();
            public class AlreadySetException() : CustomException
                ("Email.AlreadySet", "Значение совпадает с предыдущим");
        }
        public class PasswordHashedExp
        {

            public static EmptyException Empty => new();
            public class EmptyException() : CustomException
                ("PasswordHashed.Empty", "Пустое поле");

            public static TooLongException TooLong => new();
            public class TooLongException() : CustomException(
                "PasswordHashed.TooLong",
                $"Поле слишком длинное. Максимальная длина {Domain.ValueObjects.PasswordHashed.MAX_LENGTH} символов");

            public static TooShortException TooShort => new();
            public class TooShortException() : CustomException(
                "PasswordHashed.TooShort",
                $"Поле слишком короткое. Минимальная длина {Domain.ValueObjects.PasswordHashed.MIN_LENGTH} символа");

            public static AlreadySetException AlreadySet => new();
            public class AlreadySetException() : CustomException(
                "PasswordHashed.AlreadySet",
                "Значение совпадает с предыдущим");
        }
        public class PhoneNumberExp
        {
            public static EmptyException Empty => new();
            public class EmptyException() : CustomException
                ("PhoneNumber.Empty", "Телефон пуст");

            public static TooLongException TooLong => new();
            public class TooLongException() : CustomException
                ("PhoneNumber.TooLong", "Телефон слишком длинный");

            public static TooShortException TooShort => new();
            public class TooShortException() : CustomException
                ("PhoneNumber.TooShort", "Телефон слишком короткий");

            public static InvalidFormatException InvalidFormat => new();
            public class InvalidFormatException() : CustomException
                ("PhoneNumber.InvalidFormat", "Телефон имеет неверный формат или размер");

            public static AlreadyVerifiedException AlreadyVerified => new();
            public class AlreadyVerifiedException() : CustomException
                ("PhoneNumber.AlreadyVerified", "Телефон уже подтвержден");

            public static AlreadySetException AlreadySet => new();
            public class AlreadySetException() : CustomException
                ("PhoneNumber.AlreadySet", "Значение совпадает с предыдущим");
        }
        public static class TextExp
        {
            public static EmptyException Empty => new();
            public class EmptyException() : CustomException
                ("Text.Empty", "Содержание пусто");

            public static TooLongException TooLong => new();
            public class TooLongException() : CustomException
                ("Text.TooLong", "Содержание слишком длинное");

            public static AlreadySetException AlreadySet => new();
            public class AlreadySetException() : CustomException
                ("Text.AlreadySet", "Значение совпадает с предыдущим");
        }
        public static class TitleExp
        {
            public static EmptyException Empty => new();
            public class EmptyException() : CustomException
                ("Title.Empty", "Название пусто");

            public static TooLongException TooLong => new();
            public class TooLongException() : CustomException
                ("Title.TooLong", "Название слишком длинное");

            public static AlreadySetException AlreadySet => new();
            public class AlreadySetException() : CustomException
                ("Title.AlreadySet", "Значение совпадает с предыдущим");
        }
        public static class UsernameExp
        {
            public static EmptyException Empty => new();
            public class EmptyException() : CustomException
                ("Username.Empty", "Пустое поле");

            public static TooLongException TooLong => new();
            public class TooLongException() : CustomException
                ("Username.TooLong", $"Поле слишком длинное. Максимальная длина {Domain.ValueObjects.Username.MAX_LENGTH} символов");

            public static TooShortException TooShort => new();
            public class TooShortException() : CustomException
                ("Username.TooShort", $"Поле слишком короткое. Минимальная длина {Domain.ValueObjects.Username.MIN_LENGTH} символа");

            public static AlreadySetException AlreadySet => new();
            public class AlreadySetException() : CustomException
                ("Username.AlreadySet", "Имя пользователя совпадает с предыдущим");
        }
    }
}