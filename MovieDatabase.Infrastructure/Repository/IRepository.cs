using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Infrastructure.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ICollection<TEntity> GetAll();

        TEntity? GetById(int id);

        void Insert(TEntity entity);

        Task DeleteAsync(object id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);
    }
}
