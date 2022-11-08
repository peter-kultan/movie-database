using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MovieDatabase.ViewModels;

namespace MovieDatabase.Views
{
    public partial class MovieItemView : UserControl
    {
        public MovieItemView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
