namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        protected BaseEntity() { }
        protected BaseEntity(Guid id) { Id = id; CreatedAt = DateTime.UtcNow; }
    }
}
