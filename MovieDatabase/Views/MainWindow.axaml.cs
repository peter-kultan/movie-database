using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using movie_database.ViewModels;

namespace movie_database.Views
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
