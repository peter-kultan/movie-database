using MovieDatabase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieDatabase.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainWindowViewModel _viewModel;
        private ViewModelBase _back;

        public UpdateViewCommand(MainWindowViewModel viewModel)
        {
            this._viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter.GetType() == typeof(MovieViewModel))
            {
                _back = _viewModel.SelectedViewModel;
                _viewModel.SelectedViewModel = new MovieItemViewModel(_viewModel, (MovieViewModel)parameter);
            }
            else if (parameter.GetType() == typeof(TVSeriesViewModel))
            {
                _back = _viewModel.SelectedViewModel;
                _viewModel.SelectedViewModel = new TVSeriesItemViewModel(_viewModel, (TVSeriesViewModel)parameter);
            }
            else if (parameter.ToString() == "Back")
            {
                if (_back == null)
                {
                    Execute("Home");
                    return;
                }
                _viewModel.SelectedViewModel = _back;
                _back = null;
            }
            else if (parameter.ToString() == "Home")
            {
                _back = _viewModel.SelectedViewModel;
                _viewModel.SelectedViewModel = new DatabaseViewModel(_viewModel);
            }
            else if (parameter.ToString() == "Settings")
            {
                _back = _viewModel.SelectedViewModel;
                _viewModel.SelectedViewModel = new SettingsViewModel(_viewModel);
            }
        }
    }
}
