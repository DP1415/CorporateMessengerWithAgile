using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class TaskItemConfiguration : AbstractEntityTypeConfiguration<TaskItem>
    {
        public override void Configure()
        {
            PropertyTitle(t => t.Title);
            PropertyText(t => t.Description);

            builder.Property(t => t.Priority).IsRequired();
            builder.Property(t => t.Complexity).IsRequired();
            builder.Property(t => t.Deadline).IsRequired();

            builder.HasOne(t => t.Project)
                   .WithMany(p => p.TaskItems)
                   .HasForeignKey(t => t.ProjectId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Author)
                   .WithMany()
                   .HasForeignKey(t => t.AuthorId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Responsible)
                   .WithMany()
                   .HasForeignKey(t => t.ResponsibleId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.SprintWithLastMention)
                   .WithMany()
                   .HasForeignKey(t => t.SprintWithLastMentionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.ParentTask)
                   .WithMany(t => t.Subtasks)
                   .HasForeignKey(t => t.ParentTaskId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
