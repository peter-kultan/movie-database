using Microsoft.EntityFrameworkCore;
using MovieDatabase.Infrastructure.Repository;
using MovieDatabase.DAL.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Infrastructure.EfCore.Repository
{
    public class EFGenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal MovieDatabaseDbContext context;

        internal DbSet<TEntity> dbSet;

        public EFGenericRepository(MovieDatabaseDbContext dbContext)
        {
            this.context = dbContext;
            this.dbSet = context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public async Task DeleteAsync(object id)
        {
            var entityToDelete = await dbSet.FindAsync(id);
            Delete(entityToDelete);
        }

        public void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
