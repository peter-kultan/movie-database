using MovieDatabaseDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseDAL
{
    public static class DbProvider
    {
        private static MovieDbContext _movieDbContext;
        private static RepositoryDbContext _repositoryDbContext;
        private static TVSeriesDbContext _seriesDbContext;
        private static GenresDbContext _genreDbContext;

        public static MovieDbContext MovieDbContext
        {
            get
            {
                if (_movieDbContext == null)
                {
                    _movieDbContext = new();
                }
                return _movieDbContext;
            }
        }

        public static RepositoryDbContext RepositoryDbContext
        {
            get
            {
                if (_repositoryDbContext == null)
                {
                    _repositoryDbContext = new();
                }
                return _repositoryDbContext;
            }
        }

        public static TVSeriesDbContext TVSeriesDbContext
        {
            get
            {
                if (_seriesDbContext == null)
                {
                    _seriesDbContext = new();
                }
                return _seriesDbContext;
            }
        }

        public static GenresDbContext GenreDbContext
        {
            get
            {
                if (_genreDbContext == null)
                {
                    _genreDbContext = new();
                }
                return _genreDbContext;
            }
        }
    }
}
