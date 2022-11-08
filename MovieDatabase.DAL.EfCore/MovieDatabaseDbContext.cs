using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.DAL.EfCore.Models;

namespace MovieDatabaseDAL
{
    public class MovieDatabaseDbContext : DbContext
    {
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieMetadata> MoviesMetadata { get; set; }
        public DbSet<Repository> Repository { get; set; }
        public DbSet<TVSeries> TVSeries { get; set; }
        public DbSet<TVSeriesMetadata> TVSeriesMetadata { get; set; }

        public MovieDatabaseDbContext(DbContextOptions<MovieDatabaseDbContext> options) : base(options)
        {
        }

        public MovieDatabaseDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(@"Data Source=movieDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>();

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Metadata)
                .WithOne(m => m.Movie)
                .HasForeignKey<Movie>(m => m.MovieMetadataId);

            modelBuilder.Entity<TVSeries>()
                .HasOne(tv => tv.Metadata)
                .WithOne(m => m.TvSeries)
                .HasForeignKey<TVSeries>(tv => tv.MetadataId);

            modelBuilder.Entity<TVSeries>()
                .HasMany(tv => tv.Episodes)
                .WithOne(e => e.TvSeries);

            modelBuilder.Entity<Genre>().
                HasMany(mg => mg.TVSeries)
                .WithMany(tv => tv.Genres);

            modelBuilder.Entity<Genre>()
                .HasMany(mg => mg.Movies)
                .WithMany(m => m.Genres);
        }
    }
}
