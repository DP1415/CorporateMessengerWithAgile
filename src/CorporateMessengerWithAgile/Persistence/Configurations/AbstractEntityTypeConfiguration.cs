using System.Linq.Expressions;
using Domain.Entity;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public abstract class AbstractEntityTypeConfiguration<TEntity>
        : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        protected EntityTypeBuilder<TEntity> builder = null!;
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            this.builder = builder;
            builder.HasKey(user => user.Id);
            Configure();
        }
        public abstract void Configure();

        #region Свойства пользователя
        protected void PropertyEmail(Expression<Func<TEntity, Email?>> propertyExpression)
        {
            builder.OwnsOne(propertyExpression, email =>
            {
                email.Property(e => e.Value)
                    .HasColumnName(TableNames.Emails)
                    .HasMaxLength(Email.MAX_LENGTH)
                    .IsRequired();
            });
        }

        protected void PropertyPasswordHashed(Expression<Func<TEntity, PasswordHashed?>> propertyExpression)
        {
            builder.OwnsOne(propertyExpression, password =>
            {
                password.Property(p => p.Value)
                    .HasColumnName(TableNames.PasswordHashes)
                    .HasMaxLength(PasswordHashed.MAX_LENGTH)
                    .IsRequired();
            });
        }

        protected void PropertyPhoneNumber(Expression<Func<TEntity, PhoneNumber?>> propertyExpression)
        {
            builder.OwnsOne(propertyExpression, phone =>
            {
                phone.Property(p => p.Value)
                    .HasColumnName(TableNames.PhoneNumbers)
                    .HasMaxLength(PhoneNumber.MAX_LENGTH)
                    .IsRequired(false);
            });
        }

        protected void PropertyUsername(Expression<Func<TEntity, Username?>> propertyExpression)
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

        protected void PropertyText(Expression<Func<TEntity, Text?>> propertyExpression,
            bool isRequired = false)
        {
            builder.OwnsOne(propertyExpression, text =>
            {
                text.Property(t => t.Value)
                    .HasColumnName(TableNames.Texts)
                    .HasMaxLength(Text.MAX_LENGTH)
                    .IsRequired(isRequired);
            });
        }

        protected void PropertyTitle(Expression<Func<TEntity, Title?>> propertyExpression,
            bool isRequired = false)
        {
            builder.OwnsOne(propertyExpression, title =>
            {
                title.Property(t => t.Value)
                    .HasColumnName(TableNames.Titles)
                    .HasMaxLength(Title.MAX_LENGTH)
                    .IsRequired(isRequired);
            });
        }
    }
}
