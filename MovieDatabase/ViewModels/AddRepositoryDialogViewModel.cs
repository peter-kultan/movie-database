using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using MovieDatabaseDAL.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movie_database.ViewModels
{
    public class AddRepositoryDialogViewModel : ViewModelBase
    {
        public Repository? Result { get; private set; } = null;
        string[] RepositoryTypes { get; set; } = Enum.GetNames(typeof(RepositoryType));


        public Action<object> Close;
        private bool _addEnabled = false;
        private string _name = "";
        private string _path = "";
        private string _selectedType = "";
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _name, value);
                AddEnabled = Name != "" && Path != "" && SelectedType != "";
            }
        }
        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _path, value);
                AddEnabled = Name != "" && Path != "" && SelectedType != "";
            }
        }

        public bool AddEnabled
        {
            get
            {
                return _addEnabled;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _addEnabled, value);
            }
        }

        public string SelectedType
        {
            get
            {
                return _selectedType;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedType, value);
                AddEnabled = Name != "" && Path != "" && SelectedType != "";
            }
        }

        public async Task OpenFolderDialogAsync()
        {
            OpenFolderDialog dialog = new();
            if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                Path = (await dialog.ShowAsync(desktop.MainWindow));
            }
        }
        
        public void Cancel()
        {
            Close(null);
        }

        public void Add()
        {
            Result = new Repository(Name, Path, (RepositoryType)Enum.Parse(typeof(RepositoryType), SelectedType));
            Close(Result);
        }
    }
}
