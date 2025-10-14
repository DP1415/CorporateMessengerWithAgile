namespace Domain.Entity
{
    public class Employee
    {
        public Company Company { get; set; }
        public PositionInCompany PositionInCompany { get; set; }
        public User User { get; set; }
    }
}
