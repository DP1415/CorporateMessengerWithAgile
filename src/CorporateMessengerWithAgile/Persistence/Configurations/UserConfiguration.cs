using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UserConfiguration : AbstractEntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            PropertyEmail(builder, user => user.Email);
            PropertyUsername(builder, user => user.Username);
            PropertyPasswordHashed(builder, user => user.PasswordHashed);
        }

    }
}
