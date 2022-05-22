using DataSource.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Repositories
{
    public class MovieDbContext : DbContext
    {

        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieMetadata> MovieMetadata { get; set; }

        public MovieDbContext() : base()
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
