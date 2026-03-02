using Domain.Entity;

namespace Application.Dto
{
    public abstract class BaseDto
    {
        public Guid Id { get; set; }
    }

    public abstract class BaseEntityWithChatsDto : BaseDto
    {
        public IReadOnlyList<Guid> ChatIds { get; set; } = null!;
    }
}
