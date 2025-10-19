using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EmployeeConfiguration : AbstractEntityTypeConfiguration<Employee>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Employee> builder)
        {
            builder.HasOne(e => e.Company)
                   .WithMany(c => c.Employees)
                   .HasForeignKey(e => e.CompanyId);

            builder.HasOne(e => e.PositionInCompany)
                   .WithMany(pic => pic.Employees)
                   .HasForeignKey(e => e.PositionInCompanyId);

            builder.HasOne(e => e.User)
                   .WithMany()
                   .HasForeignKey(e => e.UserId);

            builder.HasMany(e => e.TeamMembers)
                   .WithOne(tm => tm.Employee)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
