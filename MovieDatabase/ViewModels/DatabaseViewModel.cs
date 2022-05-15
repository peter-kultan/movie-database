using Avalonia.Controls.ApplicationLifetimes;
using DataSource;
using DataSource.Models;
using DataSource.Repositories;
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
            var context = new MovieDbContext();
            //var repoContext = new RepositoryDbContext();
            var response = DataSource.Api.ApiController.Get("https://api.themoviedb.org/3/search/movie", new Dictionary<string, string>() { { "api_key", "a3baf7a02cdd3e1aa7b800d05ea630ea" }, { "query", "endgame" } });
            context.Add(new Movie(response.Results[0]));
            response = DataSource.Api.ApiController.Get("https://api.themoviedb.org/3/search/movie", new Dictionary<string, string>() { { "api_key", "a3baf7a02cdd3e1aa7b800d05ea630ea" }, { "query", "gran torino" } });
            context.Add(new Movie(response.Results[0]));
            context.SaveChanges();
            Movies = new ObservableCollection<MovieTVViewModel>(context.Movies.ToObservable().Select(x => new MovieTVViewModel(x)).ToEnumerable());
            Movies.Add(new MovieTVViewModel());
            LoadCovers(new CancellationToken());
        }

        public void OpenCommand(object? obj) => _parent.UpdateViewCommand.Execute(obj);

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

        public ObservableCollection<MovieTVViewModel> Movies { get; } = new();
        public ObservableCollection<MovieTVViewModel> TVSeries { get; } = new();
    }
}
