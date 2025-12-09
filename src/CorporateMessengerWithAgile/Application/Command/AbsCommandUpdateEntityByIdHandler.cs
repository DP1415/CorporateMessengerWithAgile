using Domain.Common;
using Domain.Result;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Command
{
    abstract public class AbsCommandUpdateEntityByIdHandler<TCommand, TEntity>
        : AbsCommandBaseHandler<TCommand, Result<TEntity>>
        where TCommand : AbsCommandUpdateEntityById<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> _dbSet;

        public AbsCommandUpdateEntityByIdHandler(AppDbContext context) : base(context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public override async Task<Result<TEntity>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            TEntity? entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
            if (entity == null) return new Exception($"{typeof(TEntity).Name} not found");

            Result<TEntity> updateResult = Update(entity);
            if (updateResult.IsFailure) return updateResult.Exception;

            _dbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return updateResult;
        }

        protected abstract Result<TEntity> Update(TEntity entity);
    }
}