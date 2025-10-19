using System.Linq.Expressions;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public abstract class AbstractEntityTypeConfiguration<TEntity>
        : IEntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> builder);

        #region Свойства пользователя
        protected void PropertyEmail(
            EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, Email?>> propertyExpression)
        {
            builder.ComplexProperty(propertyExpression, email =>
            {
                email.Property(e => e.Value)
                    .HasColumnName(TableNames.Emails)
                    .HasMaxLength(Email.MAX_LENGTH)
                    .IsRequired();
            });
        }

        protected void PropertyPasswordHashed(
            EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, PasswordHashed?>> propertyExpression)
        {
            builder.ComplexProperty(propertyExpression, password =>
            {
                password.Property(p => p.Value)
                    .HasColumnName(TableNames.PasswordHashes)
                    .HasMaxLength(PasswordHashed.MAX_LENGTH)
                    .IsRequired();
            });
        }

        protected void PropertyPhoneNumber(
            EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, PhoneNumber?>> propertyExpression)
        {
            builder.ComplexProperty(propertyExpression, phone =>
            {
                phone.Property(p => p.Value)
                    .HasColumnName(TableNames.PhoneNumbers)
                    .HasMaxLength(PhoneNumber.MAX_LENGTH)
                    .IsRequired(false);
            });
        }

        protected void PropertyUsername(
            EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, Username?>> propertyExpression)
        {
            builder.ComplexProperty(propertyExpression, username =>
            {
                username.Property(u => u.Value)
                    .HasColumnName(TableNames.Usernames)
                    .HasMaxLength(Username.MAX_LENGTH)
                    .IsRequired();
            });
        }
        #endregion

        protected void PropertyText(
            EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, Text?>> propertyExpression,
            bool isRequired = false)
        {
            builder.ComplexProperty(propertyExpression, text =>
            {
                text.Property(t => t.Value)
                    .HasColumnName(TableNames.Texts)
                    .HasMaxLength(Text.MAX_LENGTH)
                    .IsRequired(isRequired);
            });
        }

        protected void PropertyTitle(
            EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, Title?>> propertyExpression,
            bool isRequired = false)
        {
            builder.ComplexProperty(propertyExpression, title =>
            {
                title.Property(t => t.Value)
                    .HasColumnName(TableNames.Titles)
                    .HasMaxLength(Title.MAX_LENGTH)
                    .IsRequired(isRequired);
            });
        }
    }
}