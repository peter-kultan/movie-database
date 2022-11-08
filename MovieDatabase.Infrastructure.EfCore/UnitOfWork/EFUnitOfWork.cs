﻿using MovieDatabase.Infrastructure.EfCore.Repository;
using MovieDatabase.Infrastructure.Repository;
using MovieDatabase.Infrastructure.UnitOfWork;
using MovieDatabase.DAL.EfCore;
using MovieDatabase.DAL.EfCore.Models;

namespace MovieDatabase.Infrastructure.EfCore.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly MovieDatabaseDbContext DbContext;

        public EFUnitOfWork(MovieDatabaseDbContext dbContext)
        {
            DbContext = dbContext;

            MovieRepository = new EFGenericRepository<Movie>(DbContext);

            MovieMetadataRepositry = new EFGenericRepository<MovieMetadata>(DbContext);

            TVSeriesRepository = new EFGenericRepository<TVSeries>(DbContext);

            TVSeriesMetadataRepositury = new EFGenericRepository<TVSeriesMetadata>(DbContext);

            TVSeriesEpisodeRepository = new EFGenericRepository<TVSeriesEpisode>(DbContext);

            GenreRepository = new EFGenericRepository<Genre>(DbContext);

            RepositoryRepository = new EFGenericRepository<MovieDatabase.DAL.EfCore.Models.Repository>(DbContext);
        }

        private IRepository<Movie> MovieRepository;

        private IRepository<MovieMetadata> MovieMetadataRepositry;

        private IRepository<TVSeries> TVSeriesRepository;

        private IRepository<TVSeriesMetadata> TVSeriesMetadataRepositury;

        private IRepository<TVSeriesEpisode> TVSeriesEpisodeRepository;

        private IRepository<Genre> GenreRepository;

        private IRepository<MovieDatabase.DAL.EfCore.Models.Repository> RepositoryRepository;

        

        public async Task Commit()
        {
            await DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
