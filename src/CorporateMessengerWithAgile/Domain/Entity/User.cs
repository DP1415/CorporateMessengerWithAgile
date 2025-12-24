using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entity
{
    public class User : BaseEntity
    {
        public Email Email { get; set; } = null!;
        public Username Username { get; set; } = null!;
        public PasswordHashed PasswordHashed { get; set; } = null!;
        public PhoneNumber PhoneNumber { get; set; } = null!;

        public ICollection<Employee> Employees { get; set; } = [];

        public User() : base() { }
        public User(Guid id) : base(id) { }
    }
}