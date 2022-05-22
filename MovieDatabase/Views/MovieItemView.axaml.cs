using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using movie_database.ViewModels;

namespace movie_database.Views
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
