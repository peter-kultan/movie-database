using movie_database.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace movie_database.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainWindowViewModel viewModel;

        public UpdateViewCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter.ToString() == "Home")
            {
                viewModel.SelectedViewModel = new DatabaseViewModel(viewModel);
            }
            else if (parameter.ToString() == "Settings")
            {
                viewModel.SelectedViewModel = new SettingsViewModel(viewModel);
            }
        }
    }
}
