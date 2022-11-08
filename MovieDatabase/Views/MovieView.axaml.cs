using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MovieDatabase.Views
{
    public partial class MovieView : UserControl
    {
        public MovieView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
