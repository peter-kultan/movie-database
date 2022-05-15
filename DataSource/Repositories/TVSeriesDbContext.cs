using DataSource.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Repositories
{
    public class TVSeriesDbContext : DbContext
    {
        public DbSet<TVSeries> TVSeries { get; set; }
        public DbSet<TVSeriesMetadata> seriesMetadatas { get; set; }

        public TVSeriesDbContext() : base()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(@"Data Source=tvDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TVSeries>()
                .HasOne(b => b.TVSeriesMetadata);
            modelBuilder.Entity<TVSeriesMetadata>()
                .HasMany(e => e.TVSeriesGenres);
            modelBuilder.Entity<TVSeriesMetadata>()
                .Property(e => e.OriginCountries)
                .HasConversion(
                    v => string.Join("|", v),
                    v => v.Split('|', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
