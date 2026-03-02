using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class ChatMemberConfiguration : AbstractEntityTypeConfiguration<ChatMember>
    {
        public override void ConfigureEntity()
        {
            builder.Property(chatMember => chatMember.IsAdmin).IsRequired();

            builder.HasOne(chatMember => chatMember.Chat)
                   .WithMany(chat => chat.Members)
                   .HasForeignKey(chatMember => chatMember.ChatId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(chatMember => chatMember.User)
                   .WithMany(user => user.ChatMembers)
                   .HasForeignKey(chatMember => chatMember.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
