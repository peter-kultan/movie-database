using Avalonia.Controls.ApplicationLifetimes;
using MovieDatabaseDAL;
using MovieDatabaseDAL.Models;
using MovieDatabaseDAL.Repositories;
using Microsoft.EntityFrameworkCore;
using movie_database.Views;
using ReactiveUI;
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
            ReloadMovies();
            ReloadTVs();
            LoadCovers(new CancellationToken());
        }


        public void OpenCommand(object? obj) => _parent.UpdateViewCommand.Execute(obj);

        public void OpenMovieDetailsCommand() => OpenCommand(SelectedMovie);
        public void OpenTVSeriesDetailsCommand() => OpenCommand(SelectedTVSeries);

        private MovieViewModel _selectedMovie;
        private TVSeriesViewModel _selectedtvSeries;
        private bool _isSelectedMovie;
        private bool _isSelectedTVSeries;
        public MovieViewModel SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                IsSelectedMovie = value != null;
            }
        }

        public bool IsSelectedMovie
        {
            get => _isSelectedMovie;
            set => this.RaiseAndSetIfChanged(ref _isSelectedMovie, value);
        }

        public TVSeriesViewModel SelectedTVSeries
        {
            get => _selectedtvSeries;
            set
            {
                _selectedtvSeries = value;
                IsSelectedTVSeries = value != null;
            }
        }

        public bool IsSelectedTVSeries
        {
            get => _isSelectedTVSeries;
            set => this.RaiseAndSetIfChanged(ref _isSelectedTVSeries, value);
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
            var repos = await DbProvider.RepositoryDbContext.Repository.Where(x => x.RepositoryType == RepositoryType.Movie).ToListAsync();
            foreach(var repo in repos)
            {
                var movies = await RepositoryDiscoverer.DiscoverFilmRepository(repo.Path);
                foreach(var movie in movies)
                {
                    if (!DbProvider.MovieDbContext.Movie.Any(m => m.Name == movie.Name))
                    {
                        DbProvider.MovieDbContext.Add(movie);
                    }
                    Movies.Add(new(movie));
                } 
            }
            LoadCovers(new CancellationToken());
            DbProvider.MovieDbContext.SaveChanges();
        }

        public async void ReloadTVs()
        {
            TVSeries = new();
            var repos = await DbProvider.RepositoryDbContext.Repository.Where(x => x.RepositoryType == RepositoryType.TVSeries).ToListAsync();
            foreach(var repo in repos)
            {
                var tvs = await RepositoryDiscoverer.DiscoverTVRepository(repo.Path);
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
        }

        public ObservableCollection<MovieViewModel> Movies { get; set; } = new();
        public ObservableCollection<TVSeriesViewModel> TVSeries { get; set; } = new();
    }
}
