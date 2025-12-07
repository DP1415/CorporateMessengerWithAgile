using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Query
{
    abstract public class AbsQueryGetAllEntityHandler<TQueryGetAllEntity, TEntity> : IRequestHandler<TQueryGetAllEntity, TEntity[]>
        where TQueryGetAllEntity : AbsQueryGetAllEntity<TEntity>
        where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbset;

        public AbsQueryGetAllEntityHandler(AppDbContext context)
        {
            _dbset = context.Set<TEntity>();
        }

        public async Task<TEntity[]> Handle(TQueryGetAllEntity request, CancellationToken cancellationToken)
        {
            TEntity[] result = await _dbset.ToArrayAsync(cancellationToken);
            return result;
        }
    }
}
