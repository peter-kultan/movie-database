using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieDatabase.DAL.EfCore;
using MovieDatabase.DAL.EfCore.Models;
using MovieDatabase.Infrastructure.EfCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MovieDatabase.Infrastructure.EFCore.Tests
{
    public class QueryObjectTests
    {
        private readonly DbContextOptions<MovieDatabaseDbContext> _options;

        public QueryObjectTests()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();
            _options = new DbContextOptionsBuilder<MovieDatabaseDbContext>().UseSqlite(connection).Options;

            using var _dbContext = new MovieDatabaseDbContext(_options);

            _dbContext.Database.EnsureCreated();

            _dbContext.TVSeriesMetadata.Add(
                new TVSeriesMetadata
                {
                    Id = 1,
                    BackdropPath = "path/to/image.jpg",
                    FirstAirDate = "10/10/2020",
                    Name = "TVSeries1",
                    VoteAverage = 2.5,
                    OriginalLanguage = "Czech",
                    OriginalName = "TVSeries1",
                    OriginCountries = new() { "Slovakia", "Czechia"},
                    Overview = "",
                    Popularity = 0,
                    PosterPath = "",
                    Tmdb = 5,
                    VoteCount = 45
                    });
            _dbContext.TVSeries.Add(new TVSeries() { Episodes = new(), Genres = new(), Id = 1, MetadataId = 1, Name = "TVSeries1" });

            _dbContext.TVSeriesMetadata.Add(
                new TVSeriesMetadata
                {
                    Id = 2,
                    BackdropPath = "path/to/image2.jpg",
                    FirstAirDate = "04/05/1990",
                    Name = "TVSeries2",
                    VoteAverage = 5,
                    OriginalLanguage = "English",
                    OriginalName = "TVSeries2.5",
                    OriginCountries = new() { "USA", "UK" },
                    Overview = "",
                    Popularity = 0,
                    PosterPath = "",
                    Tmdb = 5,
                    VoteCount = 45
                });

            _dbContext.TVSeries.Add(new() { Episodes = new(), Genres = new(), Id = 2, MetadataId = 2, Name = "TVSeries2" });
            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task Where_OneValidPredicate_Filtered()
        {
            using var _dbContext = new MovieDatabaseDbContext(_options);
            var queryObject = new EFCoreQueryObject<TVSeries>(_dbContext);
            queryObject.Filter(x => x.Name.Equals("TVSeries1"));

            var result = await queryObject.ExecuteAsync();

            Assert.True(result.Count() == 1);
        }
    }
}
