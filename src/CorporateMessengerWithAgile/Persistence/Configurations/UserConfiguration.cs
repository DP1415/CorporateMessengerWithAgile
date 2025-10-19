using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UserConfiguration : AbstractEntityTypeConfiguration<User>
    {
        public override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            PropertyEmail(builder, user => user.Email);
            PropertyUsername(builder, user => user.Username);
            PropertyPasswordHashed(builder, user => user.PasswordHashed);
        }
    }
}
