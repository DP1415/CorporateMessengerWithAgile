using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class CompanyConfiguration : AbstractEntityTypeConfiguration<Company>
    {
        public override void Configure()
        {
            PropertyTitle(c => c.Title);
        }
    }
}
