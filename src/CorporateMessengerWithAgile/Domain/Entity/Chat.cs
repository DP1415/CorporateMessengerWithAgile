using Domain.ValueObjects;

namespace Domain.Entity
{
    public class Chat : BaseEntity
    {
        public Title Name { get; set; } = null!;
        public Text Description { get; set; } = null!;

        #region Owner
        public BaseEntityWithChats? GetOwner() =>
            OwnerEmployee is not null ? OwnerEmployee :
            OwnerTeam is not null ? OwnerTeam :
            null;
        public Guid? GetOwnerId() => OwnerEmployeeId ?? OwnerTeamId;

        public Employee? OwnerEmployee { get; set; }
        public Guid? OwnerEmployeeId { get; set; }

        public Team? OwnerTeam { get; set; }
        public Guid? OwnerTeamId { get; set; }
        #endregion

        public ICollection<Message> Messages { get; set; } = [];
        public ICollection<ChatMember> Members { get; set; } = [];
    }
}
