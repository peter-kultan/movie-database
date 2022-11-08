using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.DAL.EfCore
{
    public static class DbProvider
    {
        private static MovieDatabaseDbContext _dbContext;

        public static MovieDatabaseDbContext DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new();
                }
                return _dbContext;
            }
        }
    }
}
