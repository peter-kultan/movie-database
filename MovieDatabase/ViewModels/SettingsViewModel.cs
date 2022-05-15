using Avalonia.Controls.ApplicationLifetimes;
using DataSource.Models;
using movie_database.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movie_database.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private MainWindowViewModel _parent;
        public SettingsViewModel(MainWindowViewModel parent)
        {
            _parent = parent;
            Repos.Add(new("Movies", "/agr/d/f/gf/d", RepositoryType.Movie));
            Repos.Add(new("TVSeries", "ds/f/dsf/ds/f", RepositoryType.TVSeries));
            Repos.Add(new("TVSeries", "ds/f/dsf/ds/f", RepositoryType.TVSeries));
            Repos.Add(new("TVSeries", "ds/f/dsf/ds/f", RepositoryType.TVSeries));
            Repos.Add(new("TVSeries", "ds/f/dsf/ds/f", RepositoryType.TVSeries));
            Repos.Add(new("TVSeries", "ds/f/dsf/ds/f", RepositoryType.TVSeries));
            Repos.Add(new("TVSeries", "ds/f/dsf/ds/f", RepositoryType.TVSeries));
            Repos.Add(new("TVSeries", "ds/f/dsf/ds/f", RepositoryType.TVSeries));
            Repos.Add(new("TVSeries", "ds/f/dsf/ds/f", RepositoryType.TVSeries));
            Repos.Add(new("TVSeries", "ds/f/dsf/ds/f", RepositoryType.TVSeries));
            Repos.Add(new("TVSeries", "ds/f/dsf/ds/f", RepositoryType.TVSeries));
            Repos.Add(new("TVSeries", "ds/f/dsf/ds/f", RepositoryType.TVSeries));
            Repos.Add(new("TVSeries", "ds/f/dsf/ds/f", RepositoryType.TVSeries));
            Repos.Add(new("TVSeries", "ds/f/dsf/ds/f", RepositoryType.TVSeries));
            Repos.Add(new("TVSeries", "ds/f/dsf/ds/f", RepositoryType.TVSeries));
            Repos.Add(new("TVSeries", "ds/f/dsf/ds/f", RepositoryType.TVSeries));
            Repos.Add(new("TVSeries", "ds/f/dsf/ds/f", RepositoryType.TVSeries));
            Repos.Add(new("TVSeries", "ds/f/dsf/ds/f", RepositoryType.TVSeries));
            Repos.Add(new("TVSeries", "ds/f/dsf/ds/f", RepositoryType.TVSeries));
        }

        public ObservableCollection<Repository> Repos { get; set; } = new();
        public void BackCommand() => _parent.UpdateViewCommand.Execute("Home");

        public void AddRepo()
        {
            var dialog = new AddRepositoryDialogView();
            if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                dialog.ShowDialog(desktop.MainWindow);
            }
        }
    }
}
