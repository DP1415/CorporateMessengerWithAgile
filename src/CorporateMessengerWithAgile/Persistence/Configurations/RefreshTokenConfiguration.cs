using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    class RefreshTokenConfiguration : AbstractEntityTypeConfiguration<RefreshToken>
    {
        public override void Configure()
        {
            // wip добавление свойства token через valueobject
            builder.Property(rt => rt.IsRevoked).IsRequired();
            builder.Property(rt => rt.ExpiresAt).IsRequired();

            builder.HasOne(rt => rt.User)
                   .WithOne(u => u.RefreshToken)
                   .HasForeignKey<RefreshToken>(rt => rt.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
