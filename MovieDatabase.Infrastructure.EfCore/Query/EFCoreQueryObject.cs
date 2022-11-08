using Microsoft.EntityFrameworkCore;
using MovieDatabase.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Infrastructure.EfCore.Query
{
    public class EFCoreQueryObject<TEntity> : QueryObject<TEntity> where TEntity : class, new()
    {
        private readonly DbContext _dbContext;

        public EFCoreQueryObject(DbContext dbContext)
        {
            _dbContext = dbContext;
            _query = _dbContext.Set<TEntity>().AsQueryable();
        }

        public override async Task<IEnumerable<TEntity>> ExecuteAsync()
        {
            return await _query.ToListAsync();
        }
    }
}
