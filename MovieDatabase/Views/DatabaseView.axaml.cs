using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MovieDatabase.Views
{
    public partial class DatabaseView : UserControl
    {
        public DatabaseView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
