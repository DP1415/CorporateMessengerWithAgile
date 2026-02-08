using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class TaskItemInSprintConfiguration : AbstractEntityTypeConfiguration<TaskItemInSprint>
    {
        public override void Configure()
        {
            builder.Property(tis => tis.TaskStatus).IsRequired();

            builder.HasOne(tis => tis.TaskItem)
                   .WithMany(t => t.TaskItemInSprints)
                   .HasForeignKey(tis => tis.TaskItemId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(tis => tis.Sprint)
                   .WithMany(s => s.TaskItemInSprints)
                   .HasForeignKey(tis => tis.SprintId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}