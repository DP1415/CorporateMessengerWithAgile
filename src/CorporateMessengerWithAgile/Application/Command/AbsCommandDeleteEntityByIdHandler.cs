using Domain.Common;
using Domain.Result;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Command
{
    abstract public class AbsCommandDeleteEntityByIdHandler<TCommand, TEntity>
        : AbsCommandBaseHandler<TCommand, Result>
        where TCommand : AbsCommandDeleteEntityById<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> _dbSet;

        public AbsCommandDeleteEntityByIdHandler(AppDbContext context) : base(context, null!)
        {
            _dbSet = context.Set<TEntity>();
        }

        public override async Task<Result> Handle(TCommand request, CancellationToken cancellationToken)
        {
            TEntity? entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
            if (entity == null) return new Exception($"{typeof(TEntity).Name} not found");

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
