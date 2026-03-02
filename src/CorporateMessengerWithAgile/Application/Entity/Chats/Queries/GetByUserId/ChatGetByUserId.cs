using Application.AbsQuery;
using Application.Dto.Summary;
using Domain.Entity;

namespace Application.Entity.Chats.Queries.GetByUserId
{
    public record ChatGetByUserId
        (
            Guid UserId
        )
        : AbsQuery<Chat, IEnumerable<ChatSummaryDto>>;
}
