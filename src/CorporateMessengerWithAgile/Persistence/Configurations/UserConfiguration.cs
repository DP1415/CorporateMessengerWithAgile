using Domain.Entity;
using Domain.ValueObjects;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

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

        #region Свойства пользователя
        protected void PropertyEmail(Expression<Func<User, Email?>> propertyExpression)
        {
            builder.OwnsOne(propertyExpression, email =>
            {
                email.Property(e => e.Value)
                    .HasColumnName(TableNames.Emails)
                    .HasMaxLength(Email.MAX_LENGTH)
                    .IsRequired();
            });
        }

        protected void PropertyPasswordHashed(Expression<Func<User, PasswordHashed?>> propertyExpression)
        {
            builder.OwnsOne(propertyExpression, password =>
            {
                password.Property(p => p.Value)
                    .HasColumnName(TableNames.PasswordHashes)
                    .HasMaxLength(PasswordHashed.MAX_LENGTH)
                    .IsRequired();
            });
        }

        protected void PropertyPhoneNumber(Expression<Func<User, PhoneNumber?>> propertyExpression)
        {
            builder.OwnsOne(propertyExpression, phone =>
            {
                phone.Property(p => p.Value)
                    .HasColumnName(TableNames.PhoneNumbers)
                    .HasMaxLength(PhoneNumber.MAX_LENGTH)
                    .IsRequired(false);
            });
        }

        protected void PropertyUsername(Expression<Func<User, Username?>> propertyExpression)
        {
            builder.OwnsOne(propertyExpression, username =>
            {
                username.Property(u => u.Value)
                    .HasColumnName(TableNames.Usernames)
                    .HasMaxLength(Username.MAX_LENGTH)
                    .IsRequired();
            });
        }
        #endregion
    }
}
