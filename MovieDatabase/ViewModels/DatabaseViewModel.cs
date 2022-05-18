using Avalonia.Controls.ApplicationLifetimes;
using DataSource;
using DataSource.Models;
using DataSource.Repositories;
using Microsoft.EntityFrameworkCore;
using movie_database.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace movie_database.ViewModels
{
    public class DatabaseViewModel : ViewModelBase
    {
        public MainWindowViewModel _parent;
        public DatabaseViewModel(MainWindowViewModel parent)
        {
            _parent = parent;

            Utils.Init();
            LoadMovies();
            LoadTVs();
            LoadCovers(new CancellationToken());
        }

        private async void LoadMovies()
        {
            //var db =  DbProvider.MovieDbContext;
            //var movies = await db.Movies.Include("MovieMetadata").ToListAsync();
            //foreach (var movie in movies)
            //{
            //    Movies.Add(new(movie));
            //}
            ReloadMovies();
        }

        private async void LoadTVs()
        {
            //var db = DbProvider.TVSeriesDbContext;
            //var tvSeries = await db.TVSeries.Include("TVSeriesMetadata").ToListAsync();
            //foreach (var tv in tvSeries)
            //{
            //    TVSeries.Add(new(tv));
            //}
            ReloadTVs();
        }


        public void OpenCommand(object? obj) => _parent.UpdateViewCommand.Execute(obj);

        private MovieTVViewModel _selectedMovie;
        public MovieTVViewModel SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                if (value != null)
                {
                    _parent.UpdateViewCommand.Execute(value);
                }
            }
        }

        private async void LoadCovers(CancellationToken cancellationToken)
        {
            foreach (var movie in Movies)
            {
                await movie.LoadCover();

                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }
            }

            foreach (var tv in TVSeries)
            {
                await tv.LoadCover();

                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }
            }
        }

        public async void ReloadMovies()
        {
            Movies = new();
            var repos = await DbProvider.RepositoryDbContext.Repos.Where(x => x.RepositoryType == RepositoryType.Movie).ToListAsync();
            foreach(var repo in repos)
            {
                var movies = RepositoryDiscoverer.DiscoverFilmRepository(repo.Path);
                foreach(var movie in movies)
                {
                    if (!DbProvider.MovieDbContext.Movies.Any(m => m.Name == movie.Name))
                    {
                        DbProvider.MovieDbContext.Add(movie);
                    }
                    Movies.Add(new(movie));
                }
            }
            DbProvider.MovieDbContext.SaveChangesAsync();
            LoadCovers(new CancellationToken());
        }

        public async void ReloadTVs()
        {
            TVSeries = new();
            var repos = await DbProvider.RepositoryDbContext.Repos.Where(x => x.RepositoryType == RepositoryType.TVSeries).ToListAsync();
            foreach(var repo in repos)
            {
                var tvs = RepositoryDiscoverer.DiscoverTVRepository(repo.Path);
                foreach(var tv in tvs)
                {
                    if (!DbProvider.TVSeriesDbContext.TVSeries.Any(s => s.Name == tv.Name))
                    {
                        DbProvider.TVSeriesDbContext.Add(tv);
                    }
                    TVSeries.Add(new(tv));
                }
            }
            DbProvider.TVSeriesDbContext.SaveChangesAsync();
            LoadCovers(new CancellationToken());
        }

        public ObservableCollection<MovieTVViewModel> Movies { get; set; } = new();
        public ObservableCollection<MovieTVViewModel> TVSeries { get; set; } = new();
    }
}
