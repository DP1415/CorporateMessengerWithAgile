using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class MessageConfiguration : AbstractEntityTypeConfiguration<Message>
    {
        public override void ConfigureEntity()
        {
            PropertyText(message => message.Content);
            builder.Property(message => message.IsEdited).IsRequired();

            builder.HasOne(message => message.Chat)
                   .WithMany()
                   .HasForeignKey(message => message.ChatId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(message => message.Sender)
                   .WithMany()
                   .HasForeignKey(message => message.SenderId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
