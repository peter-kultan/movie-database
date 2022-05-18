using Avalonia.Media.Imaging;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace movie_database.ViewModels
{
    public class MovieItemViewModel : ViewModelBase
    {
        private Bitmap? _back;
        private MovieTVViewModel _movieTVViewModel;
        private MainWindowViewModel _parent;
        public MovieItemViewModel(MainWindowViewModel parent, MovieTVViewModel movieTVViewModel)
        {
            _parent = parent;
            _movieTVViewModel = movieTVViewModel;
            Task.Run(() => LoadBackGround());
        }

        public Bitmap? BackGround
        {
            get => _back;
            private set => this.RaiseAndSetIfChanged(ref _back, value);
        }

        public void Back() => _parent.UpdateViewCommand.Execute("Back");

        public async Task LoadBackGround()
        {
            var imagePath = "";
            if (_movieTVViewModel.Movie.MovieMetadata != null)
            {
                imagePath = _movieTVViewModel.Movie.MovieMetadata.BackdropPath;
            }
            else
            {
                return;
            }

            if (!File.Exists($".cache/BackDrops/{imagePath}"))
            {
                using (WebClient client = new())
                {
                    client.DownloadFile(new Uri($"https://image.tmdb.org/t/p/original{imagePath}"), $".cache/BackDrops{imagePath}");
                }
            }
            await using (var stream = File.OpenRead($".cache/BackDrops{imagePath}"))
            {
                BackGround = await Task.Run(() => Bitmap.DecodeToWidth(stream, 800));
            }

        }
    }
}
