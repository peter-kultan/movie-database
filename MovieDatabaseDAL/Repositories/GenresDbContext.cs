using MovieDatabaseDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseDAL.Repositories
{
    public class GenresDbContext: DbContext
    { 
        public DbSet<Genre> Genres { get; set; }

        public GenresDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(@"Data Source=movieDB.db");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
