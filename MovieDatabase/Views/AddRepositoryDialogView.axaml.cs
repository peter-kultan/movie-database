using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MovieDatabase.Views
{
    public partial class AddRepositoryDialogView : Window
    {
        public AddRepositoryDialogView()
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
