using MovieDatabaseDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseDAL.Repositories
{
    public class TVSeriesDbContext : DbContext
    {
        public DbSet<TVSeries> TVSeries { get; set; }
        public DbSet<TVSeriesMetadata> TVSeriesMetadata { get; set; }
        public DbSet<TVSeriesEpisode> TVSeriesEpisode { get; set; }
        public TVSeriesDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(@"Data Source=movieDB.db");
        }
    }
}
