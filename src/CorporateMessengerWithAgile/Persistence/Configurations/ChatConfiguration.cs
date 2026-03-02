using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace Persistence.Configurations
{
    public class ChatConfiguration : AbstractEntityTypeConfiguration<Chat>
    {
        public override void ConfigureEntity()
        {
            PropertyTitle(chat => chat.Name);
            PropertyText(chat => chat.Description);

            ConfigBaseEntityWithChats(c => c.OwnerEmployee, c => c.OwnerEmployeeId);
            ConfigBaseEntityWithChats(c => c.OwnerTeam, c => c.OwnerTeamId);
        }
        private void ConfigBaseEntityWithChats<TRelatedEntity>(
                Expression<Func<Chat, TRelatedEntity?>>? hasOne,
                Expression<Func<Chat, object?>> hasForeignKey,
                bool isRequired = false,
                DeleteBehavior onDelete = DeleteBehavior.Restrict
            ) where TRelatedEntity : BaseEntityWithChats
        {
            builder.HasOne(hasOne)
                   .WithMany(p => p.Chats)
                   .HasForeignKey(hasForeignKey)
                   .IsRequired(isRequired)
                   .OnDelete(onDelete);
        }
    }
}
