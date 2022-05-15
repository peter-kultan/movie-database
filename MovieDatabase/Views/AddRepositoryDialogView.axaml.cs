using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace movie_database.Views
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
