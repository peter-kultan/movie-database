using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Infrastructure.Query
{
    public interface IQueryObject<TEntity> where TEntity : class, new()
    {
        Task<IEnumerable<TEntity>> ExecuteAsync();

        QueryObject<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);

        QueryObject<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> selector, bool ascending = true);

        QueryObject<TEntity> Page(int page, int pageSize);
    }
}
