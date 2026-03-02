using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    class TeamConfiguration : AbstractEntityWithChatsTypeConfiguration<Team>
    {
        public override void ConfigureEntityWithChats()
        {
            PropertyTitle(t => t.Title);

            builder.Property(t => t.StandardSprintDuration)
                   .IsRequired()
                   .HasDefaultValue(14);

            builder.HasOne(t => t.Project)
                   .WithMany(p => p.Teams)
                   .HasForeignKey(t => t.ProjectId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
