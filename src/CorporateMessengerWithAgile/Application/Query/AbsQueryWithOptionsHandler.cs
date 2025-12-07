using Application.Query.Options;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Query
{
    public abstract class AbsQueryWithOptionsHandler<TQueryWithOption, TEntity> :
        IRequestHandler<TQueryWithOption, TEntity[]>
        where TQueryWithOption : AbsQueryWithOptions<TEntity>
        where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbset;

        public AbsQueryWithOptionsHandler(AppDbContext context)
        {
            _dbset = context.Set<TEntity>();
        }

        public async Task<TEntity[]> Handle(TQueryWithOption request, CancellationToken cancellationToken)
        {
            IQueryable<TEntity> query = _dbset.AsQueryable();

            foreach (AbsOption<TEntity> option in request.Options)
            {
                query = option.AddOption(query);
            }

            return await query.ToArrayAsync(cancellationToken);
        }
    }
}
