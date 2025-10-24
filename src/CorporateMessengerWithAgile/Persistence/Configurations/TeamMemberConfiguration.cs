using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class TeamMemberConfiguration : AbstractEntityTypeConfiguration<TeamMember>
    {
        public override void Configure()
        {
            builder.HasOne(tm => tm.Employee)
                   .WithMany(e => e.TeamMembers)
                   .HasForeignKey(tm => tm.EmployeeId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(tm => tm.Team)
                   .WithMany(t => t.TeamMembers)
                   .HasForeignKey(tm => tm.TeamId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
