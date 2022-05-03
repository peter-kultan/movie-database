using Avalonia.Controls;
using movie_database.Models;
using movie_database.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Windows.Input;

namespace movie_database.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {

            SettingsCommand = ReactiveCommand.Create(() =>
            {
                var window = new SettingsWindow();
                window.Show();
            });

        }

        public ICommand SettingsCommand { get; }

    }
}
