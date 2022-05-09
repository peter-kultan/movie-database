using Avalonia.Controls;
using DataSource;
using DataSource.Models;
using movie_database.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Text;
using System.Windows.Input;

namespace movie_database.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            var context = new DataSource.Repositories.TVSeriesDbContext();
            var a = new TVSeries(DataSource.Api.ApiController.Get("https://api.themoviedb.org/3/search/tv", new Dictionary<string, string>() { { "api_key", "a3baf7a02cdd3e1aa7b800d05ea630ea" }, { "query", "blacklist" } }).Results[0]);
            context.Add(a);
            context.SaveChanges();
            Movies.Add(new());
            Movies.Add(new());
            Movies.Add(new());
            Movies.Add(new());
            Movies.Add(new());
            Movies.Add(new());
            Movies.Add(new());
            Movies.Add(new());
            Movies.Add(new());
            Movies.Add(new());
        }

        public ObservableCollection<MovieTVViewModel> Movies { get; } = new();

    }
}
