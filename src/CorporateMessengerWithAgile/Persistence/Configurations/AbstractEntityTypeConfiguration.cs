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
            builder.HasKey(entity => entity.Id);
            ConfigureEntity();
        }
        public abstract void ConfigureEntity();

        protected void PropertyText(
            Expression<Func<TEntity, Text?>> propertyExpression,
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

        protected void PropertyTitle(
            Expression<Func<TEntity, Title?>> propertyExpression,
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
