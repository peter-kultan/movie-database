using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace movie_database.Views
{
    public partial class SettingsWindowView : Window
    {
        public SettingsWindowView()
        {
            InitializeComponent();
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
