using DataSource.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource
{
    public static class DbProvider
    {
        private static MovieDbContext _movieDbContext;
        private static RepositoryDbContext _repositoryDbContext;
        private static TVSeriesDbContext _seriesDbContext;

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
    }
}
