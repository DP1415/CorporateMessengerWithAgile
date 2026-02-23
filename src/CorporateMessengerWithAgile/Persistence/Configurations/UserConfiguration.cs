using Domain.Entity;

namespace Persistence.Configurations
{
    public class UserConfiguration : AbstractEntityTypeConfiguration<User>
    {
        public override void ConfigureEntity()
        {
            PropertyEmail(user => user.Email);
            PropertyUsername(user => user.Username);
            PropertyPasswordHashed(user => user.PasswordHashed);
            PropertyPhoneNumber(user => user.PhoneNumber);

            builder.Property(user => user.Role)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
