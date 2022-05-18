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

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieMetadata> MovieMetadatas { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }

        public MovieDbContext() : base()
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
                .HasOne(b => b.MovieMetadata);
            modelBuilder.Entity<MovieMetadata>()
                .HasMany(b => b.MovieGenres);
        }
    }
}
