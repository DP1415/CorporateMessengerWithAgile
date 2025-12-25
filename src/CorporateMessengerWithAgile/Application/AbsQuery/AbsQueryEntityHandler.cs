using AutoMapper;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AbsQuery
{
    public abstract class AbsQueryEntityHandler<TQuery, TEntity, TResult>(AppDbContext context, IMapper mapper)
        : AbsQueryHandler<TQuery, TResult>(context, mapper)
        where TQuery : AbsQueryEntity<TEntity, TResult>
        where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    }
}
