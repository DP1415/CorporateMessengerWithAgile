using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Abstractions.Query
{
    abstract public class AbsEntityGetAllQueryHandler<Q, T> : IRequestHandler<Q, T[]>
        where Q : AbsEntityGetAllQuery<T>
        where T : BaseEntity
    {
        private readonly DbSet<T> _dbset;

        public AbsEntityGetAllQueryHandler(AppDbContext context)
        {
            _dbset = context.Set<T>();
        }

        public async Task<T[]> Handle(Q request, CancellationToken cancellationToken)
        {
            T[] result = await _dbset.ToArrayAsync(cancellationToken);
            return result;
        }
    }
}
