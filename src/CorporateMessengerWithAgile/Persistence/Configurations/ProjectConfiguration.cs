using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    class ProjectConfiguration : AbstractEntityTypeConfiguration<Project>
    {
        public override void Configure()
        {
            PropertyTitle(p => p.Title);


            builder.HasOne(p => p.Company)
                   .WithMany(c => c.Projects)
                   .HasForeignKey(p => p.CompanyId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
