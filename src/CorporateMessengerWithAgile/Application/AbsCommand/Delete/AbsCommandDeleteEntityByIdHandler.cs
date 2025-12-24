using Domain.Entity;
using Domain.Result;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AbsCommand.Delete
{
    abstract public class AbsCommandDeleteEntityByIdHandler<TCommand, TEntity>(AppDbContext context)
        : AbsCommandOverAnEntityHandler<TCommand, TEntity, Result>(context, null!)
        where TCommand : AbsCommandDeleteEntityById<TEntity>
        where TEntity : BaseEntity
    {
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
