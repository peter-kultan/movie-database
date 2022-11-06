using Avalonia.Controls.ApplicationLifetimes;
using MovieDatabaseDAL;
using MovieDatabaseDAL.Models;
using Microsoft.EntityFrameworkCore;
using movie_database.Views;
using ReactiveUI;
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
        public ObservableCollection<Repository> Repos { get; set; } = new();
        public void BackCommand() => _parent.UpdateViewCommand.Execute("Back");
        public SettingsViewModel(MainWindowViewModel parent)
        {
            _parent = parent;
            LoadRepositories();
        }
        private Settings _settings;
        public string ApiKey
        {
            get
            {
                if (_settings == null)
                {
                    _settings = Utils.LoadSettings();
                }
                return _settings.ApiKey;
            }
            set
            {
                _settings.ApiKey = value;
                _settings.Save();
            }
        }
        private async void LoadRepositories()
        {
            var repositories = await Task.Run(() => DbProvider.DbContext.Repository.ToListAsync());
            foreach(var repo in repositories)
            {
                Repos.Add(repo);
            }
        }

        private Repository _selected;
        public Repository Selected 
        { 
            get
            {
                return _selected;
            } 
            set 
            { 
                this.RaiseAndSetIfChanged(ref _selected, value);
                IsSelected = Selected != null;
            }
        }
        private bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _isSelected, value);
            }
        }

        public void Delete()
        {
            DbProvider.DbContext.Remove(Selected);
            Repos.Remove(Selected);
            DbProvider.DbContext.SaveChanges();
        }

        public async void Edit()
        {
            var dialog = new AddRepositoryDialogView();
            var vm = new AddRepositoryDialogViewModel();
            vm.Name = Selected.Name;
            vm.Path = Selected.Path;
            vm.SelectedType = Selected.RepositoryType.ToString();
            dialog.DataContext = vm;
            vm.Close = new Action<object>(dialog.Close);
            if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var dr = dialog.ShowDialog<object>(desktop.MainWindow);
                var repo = await dr;
                if (repo != null)
                {
                    var oldRepo = Selected;
                    var newRepo = (Repository)repo;
                    Repos.Remove(oldRepo);
                    Repos.Add(newRepo);
                    Selected = newRepo;

                    oldRepo.Name = newRepo.Name;
                    oldRepo.Path = newRepo.Path;
                    oldRepo.RepositoryType = newRepo.RepositoryType;
                    DbProvider.DbContext.Update(oldRepo);
                    DbProvider.DbContext.SaveChanges();
                }
            }
        }

        public async void AddRepo()
        {
            var dialog = new AddRepositoryDialogView();
            var vm = new AddRepositoryDialogViewModel();
            dialog.DataContext = vm;
            vm.Close = new Action<Object>(dialog.Close);
            if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var dr = dialog.ShowDialog<object>(desktop.MainWindow);
                var repo = await dr;
                if (repo != null)
                {
                    var newRepo = (Repository)repo;
                    Repos.Add(newRepo);
                    DbProvider.DbContext.Add(newRepo);
                    DbProvider.DbContext.SaveChanges();
                }
            }
        }
    }
}
