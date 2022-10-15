using MovieDatabaseDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseDAL.Repositories
{
    public class CreateDatabaseDbContext : DbContext
    {
        public CreateDatabaseDbContext() : base()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(@"Data Source=movieDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Metadata);
            modelBuilder.Entity<TVSeries>()
                .HasOne(tv => tv.Metadata);
            modelBuilder.Entity<TVSeries>()
                .HasMany(tv => tv.Episodes);
            modelBuilder.Entity<TVSeriesMetadata>();
            modelBuilder.Entity<Repository>();
            modelBuilder.Entity<Genre>().
                HasMany(mg => mg.TVSeries);
            modelBuilder.Entity<Genre>()
                .HasMany(mg => mg.Movies);
        }
    }
}
