using Domain.Entity;

namespace Persistence.Configurations
{
    public class UserConfiguration : AbstractEntityTypeConfiguration<User>
    {
        public override void Configure()
        {
            PropertyEmail(user => user.Email);
            PropertyUsername(user => user.Username);
            PropertyPasswordHashed(user => user.PasswordHashed);
        }
    }
}
