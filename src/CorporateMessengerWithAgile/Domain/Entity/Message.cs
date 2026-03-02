using Domain.ValueObjects;

namespace Domain.Entity
{
    public class Message : BaseEntity
    {
        public Text Content { get; set; } = null!;

        public Chat Chat { get; set; } = null!;
        public Guid ChatId { get; set; }

        public User Sender { get; set; } = null!;
        public Guid SenderId { get; set; }

        public bool IsEdited { get; set; }
    }
}