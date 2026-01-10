using Domain.Result;
using Microsoft.AspNetCore.Http;

namespace Application
{
    public class ApplicationErrors
    {
        public class EntityError
        {
            public static EntityNotFound NotFound(string entityName) => new(entityName);
            public class EntityNotFound(string entityName) : Error("Entity.NotFound", $"{entityName} не найден", StatusCodes.Status404NotFound);
        }

        public class AuthenticationError
        {
            public static InvalidCredentials Invalid => new();
            public class InvalidCredentials() : Error("Authentication.InvalidCredentials", "Неверное имя пользователя или пароль", StatusCodes.Status401Unauthorized);
        }

        public class CompanyError
        {
            public static CompanyNotFound NotFound(Guid id) => new(id);
            public class CompanyNotFound(Guid id) : Error("Company.NotFound", $"Компания с ID {id} не найдена", StatusCodes.Status404NotFound);
        }
    }
}