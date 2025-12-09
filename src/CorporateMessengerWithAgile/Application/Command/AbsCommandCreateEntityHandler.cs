using Domain.Common;
using Domain.Result;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Command
{
    abstract public class AbsCommandCreateEntityHandler<TCommand, TEntity>
        : AbsCommandBaseHandler<TCommand, Result<TEntity>>
        where TCommand : AbsCommandCreateEntity<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> _dbSet;

        public AbsCommandCreateEntityHandler(AppDbContext context) : base(context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public override async Task<Result<TEntity>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            Result<TEntity> entity = Create(request);
            if (entity.IsFailure) return entity.Exception;

            await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Value;
        }

        public abstract Result<TEntity> Create(TCommand request);
    }
}
