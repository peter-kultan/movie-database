using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
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
                    var connection = new SqliteConnection(@"Data Source=..\..\..\..\MovieDatabase.DAL.EfCore\movieDB.db");

                    connection.Open();

                    var options = new DbContextOptionsBuilder<MovieDatabaseDbContext>().UseSqlite(connection).Options;
                   _dbContext = new MovieDatabaseDbContext(options);
                }
                return _dbContext;
            }
        }
    }
}
