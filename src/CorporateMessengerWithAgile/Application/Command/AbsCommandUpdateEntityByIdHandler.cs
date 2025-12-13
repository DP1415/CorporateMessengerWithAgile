using Domain.Common;
using Domain.Result;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Command
{
    abstract public class AbsCommandUpdateEntityByIdHandler<TCommand, TEntity>(AppDbContext context)
        : AbsCommandUpdateEntityBaseHandler<TCommand, TEntity>(context)
        where TCommand : AbsCommandUpdateEntityById<TEntity>
        where TEntity : BaseEntity
    {
        protected override Task<TEntity?> GetEntity(TCommand request, CancellationToken cancellationToken) =>
            _dbSet.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
    }
}