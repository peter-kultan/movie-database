using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MovieDatabase.ViewModels;

namespace MovieDatabase.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
