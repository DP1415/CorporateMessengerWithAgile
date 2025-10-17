using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entity
{
    public class User : BaseEntity
    {
        //private User(Guid id) : base(id) { }
        //private User(Guid id, Email email, Username username, PasswordHashed passwordHashed) : base(id)
        //{
        //    Email = email;
        //    Username = username;
        //    PasswordHashed = passwordHashed;
        //}

        public Email Email { get; set; } = null!;
        public Username Username { get; set; } = null!;
        public PasswordHashed PasswordHashed { get; set; } = null!;

        public ICollection<Employee> Employees { get; set; } = [];
    }
}