using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using DataSource;
using DataSource.Models;
using DataSource.Repositories;
using movie_database.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace movie_database.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Utils.Init();
            var context = new MovieDbContext();
            var response = DataSource.Api.ApiController.Get("https://api.themoviedb.org/3/search/movie", new Dictionary<string, string>() { { "api_key", "a3baf7a02cdd3e1aa7b800d05ea630ea" }, { "query", "endgame" } });
            context.Add(new Movie(response.Results[0]));
            response = DataSource.Api.ApiController.Get("https://api.themoviedb.org/3/search/movie", new Dictionary<string, string>() { { "api_key", "a3baf7a02cdd3e1aa7b800d05ea630ea" }, { "query", "gran torino" } });
            context.Add(new Movie(response.Results[0]));
            context.SaveChanges();
            Movies = new ObservableCollection<MovieTVViewModel>(context.Movies.ToObservable().Select(x => new MovieTVViewModel(x)).ToEnumerable());
            Movies.Add(new MovieTVViewModel());
            LoadCovers(new CancellationToken());
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
        }

        public void ShowSettings()
        {
            var window = new SettingsWindow();
            if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                window.ShowDialog(desktop.MainWindow);
            }
        }

        public ObservableCollection<MovieTVViewModel> Movies { get; } = new();
        public ObservableCollection<MovieTVViewModel> TVSeries { get; } = new();
    }
}
