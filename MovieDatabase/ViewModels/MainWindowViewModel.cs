using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using MovieDatabaseDAL;
using MovieDatabaseDAL.Models;
using MovieDatabaseDAL.Repositories;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using movie_database.Commands;
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
        private ViewModelBase _viewModel;

        public ViewModelBase SelectedViewModel { 
            get { return _viewModel; }
            set { this.RaiseAndSetIfChanged(ref _viewModel, value); }  
        }
        public ICommand UpdateViewCommand { get; set; }

        public MainWindowViewModel()
        {
            SelectedViewModel = new DatabaseViewModel(this);
            UpdateViewCommand = new UpdateViewCommand(this);
        }
    }
}
