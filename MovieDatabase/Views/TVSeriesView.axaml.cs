using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MovieDatabase.Views
{
    public partial class TVSeriesView : UserControl
    {
        public TVSeriesView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
