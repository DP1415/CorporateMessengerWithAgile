using Domain.Result;

namespace Application
{
    public class ApplicationErrors
    {
        public class EntityError
        {
            public static EntityNotFound NotFound(string entityName) => new(entityName);
            public class EntityNotFound(string entityName) : Error("Entity.NotFound", $"{entityName} not found");
        }
    }
}
