using AutoMapper;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AbsCommand
{
    public abstract class AbsCommandOverAnEntityHandler<TCommand, TEntity, TResult>(AppDbContext context, IMapper mapper)
        : AbsCommandHandler<TCommand, TResult>(context, mapper)
        where TCommand : AbsCommandOverAnEntity<TEntity, TResult>
        where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    }
}
