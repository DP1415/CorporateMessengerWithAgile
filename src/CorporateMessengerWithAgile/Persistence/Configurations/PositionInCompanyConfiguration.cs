using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class PositionInCompanyConfiguration : AbstractEntityTypeConfiguration<PositionInCompany>
    {
        public override void Configure()
        {
            PropertyTitle(pic => pic.Title);
            PropertyText(pic => pic.Description);

            builder.HasOne(pic => pic.Company)
                   .WithMany(c => c.Positions)
                   .HasForeignKey(pic => pic.CompanyId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
