using Domain.Abstract.DBQueryDesigner;
using Domain.Common;

namespace Persistence.DBQueryDesigner
{
    public class DBQueryBuilder(AppDbContext dbContext) : IDBQueryBuilder
    {
        private readonly AppDbContext dbContext = dbContext;
        public IDBQueryDesignerSet<TEntity> Set<TEntity>() where TEntity : BaseEntity => new DBQueryDesignerSet<TEntity>(dbContext);
        public IDBQueryDesignerSingular<TEntity> Singular<TEntity>() where TEntity : BaseEntity => new DBQueryDesignerSingular<TEntity>(dbContext);
    }
}
