using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using MovieDatabase.DAL.EfCore;
using MovieDatabase.DAL.EfCore.Models;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Commands;
using MovieDatabase.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace MovieDatabase.ViewModels
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
