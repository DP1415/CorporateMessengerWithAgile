using Application.AbsQuery;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.Chats.Queries.GetByUserId
{
    public class ChatGetByUserIdHandler(AppDbContext context, IMapper mapper)
        : AbsQueryHandler<ChatGetByUserId, Chat, IEnumerable<ChatSummaryDto>>(context, mapper)
    {
        public override async Task<IEnumerable<ChatSummaryDto>> Handle(ChatGetByUserId request, CancellationToken cancellationToken)
        {
            IEnumerable<Chat> chats = (await _context.ChatMembers
                .AsNoTracking()
                .Where(cm => cm.UserId == request.UserId)
                .ToArrayAsync(cancellationToken))
                .Select(cm => cm.Chat);

            return _mapper.Map<IEnumerable<ChatSummaryDto>>(chats);
        }
    }
}