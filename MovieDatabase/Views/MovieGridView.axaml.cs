using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MovieDatabase.Views
{
    public partial class MovieGridView : UserControl
    {
        public MovieGridView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
