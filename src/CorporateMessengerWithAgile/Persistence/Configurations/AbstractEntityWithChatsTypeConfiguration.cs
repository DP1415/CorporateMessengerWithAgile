using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Configurations
{
    public abstract class AbstractEntityWithChatsTypeConfiguration<TEntity>
        : AbstractEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntityWithChats
    {
        public override void ConfigureEntity()
        {
            ConfigureEntityWithChats();
        }
        public abstract void ConfigureEntityWithChats();
    }
}
