using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieDatabase.DAL.EfCore;
using MovieDatabase.DAL.EfCore.Models;
using MovieDatabase.Infrastructure.EfCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

            var countryUSA = new Country() { Id = 3, Name = "USA" };

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
                    OriginCountries = new() { new() { Id = 1, Name = "Czechia" }, new() { Id = 2, Name = "Slovakia" } },
                    Overview = "",
                    Popularity = 30,
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
                    OriginCountries = new() { countryUSA },
                    Overview = "",
                    Popularity = 15,
                    PosterPath = "",
                    Tmdb = 5,
                    VoteCount = 60
                });
            _dbContext.TVSeries.Add(new() { Episodes = new(), Genres = new(), Id = 2, MetadataId = 2, Name = "TVSeries2" });

            _dbContext.TVSeriesMetadata.Add(
                new()
                {
                    Id = 3,
                    BackdropPath = "",
                    FirstAirDate = "08/12/2001",
                    Name = "Blacklist",
                    VoteAverage = 8,
                    OriginalLanguage = "German",
                    OriginalName = "Blacklist",
                    OriginCountries = new() { new() { Id = 4, Name = "Germany" }, countryUSA },
                    Overview = "",
                    Popularity = 55,
                    PosterPath = "path/to/poster",
                    Tmdb = 8,
                    VoteCount = 12
                });
            _dbContext.TVSeries.Add(new() { Episodes = new(), Genres = new(), Id = 3, MetadataId = 3, Name = "Blacklist" });

            _dbContext.TVSeriesMetadata.Add(
                new()
                {
                    Id = 4,
                    BackdropPath = "",
                    FirstAirDate = "12/12/2020",
                    Name = "Stranger Things",
                    VoteAverage = 1,
                    OriginalLanguage = "Spanish",
                    OriginalName = "Strange",
                    OriginCountries = new() { new() { Id = 5, Name = "Spain" }, new() { Id = 6, Name = "Portugal" }, countryUSA },
                    Overview = "Some strange overview",
                    Popularity = 1,
                    PosterPath = "No/poster",
                    Tmdb = -4,
                    VoteCount = 582153
                });
            _dbContext.TVSeries.Add(new() { Episodes = new(), Genres = new(), Id = 4, MetadataId = 4, Name = "Strange Name" });

            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task Filter_OneValidPredicate_OneResult()
        {
            using var _dbContext = new MovieDatabaseDbContext(_options);
            var queryObject = new EFCoreQueryObject<TVSeries>(_dbContext);
            queryObject.Filter(x => x.Name.Equals("TVSeries1"));

            var result = await queryObject.ExecuteAsync();

            Assert.True(result.Count() == 1);
        }

        [Fact]
        public async Task Filter_OneValidPredicate_EmptyResult()
        {
            using var _dbContext = new MovieDatabaseDbContext(_options);
            var queryObject = new EFCoreQueryObject<TVSeries>(_dbContext);
            queryObject.Filter(x => x.Name.Equals("Movie"));

            var result = await queryObject.ExecuteAsync();

            Assert.True(result.Count() == 0);
        }

        [Fact]
        public async Task Filter_TwoValidPredicate_OneResult()
        {
            using var _dbContext = new MovieDatabaseDbContext(_options);
            var queryObject = new EFCoreQueryObject<TVSeries>(_dbContext);
            queryObject.Filter(x => x.Metadata.BackdropPath.Equals("") && x.Metadata.Tmdb < 0);

            var result = await queryObject.ExecuteAsync();

            Assert.True(result.Count() == 1);
        }

        [Fact]
        public async Task Filter_TwoValidPredicate_TwoResults()
        {
            using var _dbContext = new MovieDatabaseDbContext(_options);
            var queryObject = new EFCoreQueryObject<TVSeries>(_dbContext);
            queryObject.Filter(x => x.Metadata.Overview.Equals("") && x.Metadata.VoteCount > 40);

            var result = await queryObject.ExecuteAsync();

            Assert.True(result.Count() == 2);
        }

        [Fact]
        public async Task Filter_TwoValidPredicate_MultipleResults()
        {
            using var _context = new MovieDatabaseDbContext(_options);
            var queryObject = new EFCoreQueryObject<TVSeries>(_context);
            queryObject.Filter(x => x.Metadata.Popularity > 0 && x.Name != "");

            var result = await queryObject.ExecuteAsync();

            Assert.True(result.Count() == 4);
        }

        [Fact]
        public async Task OrderBy_OneValidPreicateOrdered_TwoResultsOrdered()
        {
            using var _context = new MovieDatabaseDbContext(_options);
            var queryObject = new EFCoreQueryObject<TVSeries>(_context);
            queryObject.Filter(x => x.Metadata.BackdropPath.Equals("")).OrderBy(x => x.Name);

            var result = await queryObject.ExecuteAsync();

            Assert.True(result.Count() == 2);
            Assert.True(result.First().Id == 3);
            Assert.True(result.Last().Id == 4);
        }

        [Fact]
        public async Task OrderBy_OneValidPredicareOrderedDesc_TwoResultOrdered()
        {
            using var _context = new MovieDatabaseDbContext(_options);
            var queryObject = new EFCoreQueryObject<TVSeries>(_context);
            queryObject.Filter(x => !x.Metadata.BackdropPath.Equals("")).OrderBy(x => x.Name, false);

            var result = await queryObject.ExecuteAsync();

            Assert.True(result.Count() == 2);
            Assert.True(result.First().Id == 2);
            Assert.True(result.Last().Id == 1);
        }

        [Fact]
        public async Task Page_Paged_EmptyResult()
        {
            using var _context = new MovieDatabaseDbContext(_options);
            var queryObject = new EFCoreQueryObject<TVSeries>(_context);
            queryObject.Page(30, 5);

            var result = await queryObject.ExecuteAsync();

            Assert.True(result.Count() == 0);
        }

        [Fact]
        public async Task Page_Paged_TwoResultPaged()
        {
            using var _context = new MovieDatabaseDbContext(_options);
            var queryObject = new EFCoreQueryObject<TVSeries>(_context);
            queryObject.Page(1, 2);

            var result = await queryObject.ExecuteAsync();

            Assert.True(result.Count() == 2);
        }

        [Fact]
        public async Task Page_Paged_TooFewEntities()
        {
            using var _context = new MovieDatabaseDbContext(_options);
            var queryObject = new EFCoreQueryObject<TVSeries>(_context);
            queryObject.Page(2, 3);

            var result = await queryObject.ExecuteAsync();

            Assert.True(result.Count() == 1);
        }

        [Fact]
        public async Task Page_OrderedPaged_TwoResultsOrderedPaged()
        {
            using var _context = new MovieDatabaseDbContext(_options);
            var queryObject = new EFCoreQueryObject<TVSeries>(_context);
            queryObject.OrderBy(x => x.Name).Page(2, 2);

            var result = await queryObject.ExecuteAsync();

            Assert.True(result.Count() == 2);
            Assert.True(result.First().Id == 1);
            Assert.True(result.Last().Id == 2);
        }
    }
}
