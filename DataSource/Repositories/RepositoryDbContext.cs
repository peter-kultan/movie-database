using DataSource.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Repositories
{
    public class RepositoryDbContext : DbContext
    {
        public DbSet<Repository> Repos { get; set; }

        public RepositoryDbContext() : base()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(@"Data Source=repoDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
