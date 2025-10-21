using Domain.Abstract.DBQueryDesigner;
using Domain.Common;
using Domain.Result;
using System.Linq.Expressions;

namespace Persistence.DBQueryDesigner
{
    public class DBQueryDesignerSingular<TEntity>
        : AbstractDBQueryDesigner<
            TEntity,
            TEntity
        >,
        IDBQueryDesignerSingular<TEntity>
        where TEntity : BaseEntity
    {
        public DBQueryDesignerSingular(AppDbContext dbContext) : base(dbContext) { }

        public IDBQueryDesigner<TEntity, TEntity> Get(Guid id)
        {
            return Get(entity => entity.Id == id);
        }

        public IDBQueryDesigner<TEntity, TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            _query = _query.Where(predicate);
            return this;
        }

        protected override Task<TEntity> ExecuteQueryAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        IDBQueryDesigner<TEntity, TEntity> IDBQueryDesigner<TEntity, TEntity, IDBQueryDesigner<TEntity, TEntity>>.Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty)
        {
            throw new NotImplementedException();
        }

        IDBQueryDesignerInclude<TEntity, TEntity, TProperty, IDBQueryDesigner<TEntity, TEntity>> IDBQueryDesigner<TEntity, TEntity, IDBQueryDesigner<TEntity, TEntity>>.IncludeWith<TProperty>(Expression<Func<TEntity, TProperty>> navigationProperty)
        {
            throw new NotImplementedException();
        }
    }
}