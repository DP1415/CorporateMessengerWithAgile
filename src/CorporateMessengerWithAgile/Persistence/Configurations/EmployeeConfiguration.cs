using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class EmployeeConfiguration : AbstractEntityTypeConfiguration<Employee>
    {
        public override void Configure()
        {
            builder.HasOne(e => e.Company)
                   .WithMany(c => c.Employees)
                   .HasForeignKey(e => e.CompanyId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.PositionInCompany)
                   .WithMany(p => p.Employees)
                   .HasForeignKey(e => e.PositionInCompanyId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.User)
                   .WithMany(u => u.Employees)
                   .HasForeignKey(e => e.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
