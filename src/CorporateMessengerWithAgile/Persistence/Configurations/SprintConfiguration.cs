using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class SprintConfiguration : AbstractEntityTypeConfiguration<Sprint>
    {
        public override void Configure()
        {
            builder.Property(s => s.DateStart).IsRequired();
            builder.Property(s => s.DateEnd).IsRequired();

            builder.HasOne(s => s.Team)
                   .WithMany(t => t.Sprints)
                   .HasForeignKey(s => s.TeamId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}