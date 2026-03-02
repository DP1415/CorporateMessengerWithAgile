namespace Domain.Entity
{
    public class ChatMember : BaseEntity
    {
        public Chat Chat { get; set; } = null!;
        public Guid ChatId { get; set; }

        public User User { get; set; } = null!;
        public Guid UserId { get; set; }

        public bool IsAdmin { get; set; }
    }
}