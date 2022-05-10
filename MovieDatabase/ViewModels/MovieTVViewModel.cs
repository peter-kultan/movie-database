using DataSource.Models;
using ReactiveUI;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace movie_database.ViewModels
{
    public class MovieTVViewModel : ViewModelBase
    {
        private Bitmap? _cover;
        private Movie? _movie;
        private TVSeries? _tvSeries;

        public MovieTVViewModel(Movie? movie)
        {
            _tvSeries = null;
            _movie = movie;
        }

        public MovieTVViewModel(TVSeries? tvSeries)
        {
            _tvSeries = tvSeries;
            _movie = null;
        }

        public MovieTVViewModel()
        {
            _tvSeries = null;
            _movie = null;
        }

        public Bitmap? Cover
        {
            get => _cover;
            private set => this.RaiseAndSetIfChanged(ref _cover, value);
        }

        public async Task LoadCover()
        {
            var imagePath = _movie != null ? _movie.MovieMetadata.PosterPath : _tvSeries != null ? _tvSeries.TVSeriesMetadata.PosterPath : "";

            if (imagePath == "")
            {
                return;
            }

            if (!File.Exists($".cache/Posters/{imagePath}"))
            {
                using(WebClient client = new())
                {
                    client.DownloadFile(new Uri($"https://image.tmdb.org/t/p/original{imagePath}"), $".cache/Posters{imagePath}");
                }
            }

            await using(var stream = File.OpenRead($".cache/Posters{imagePath}"))
            {
                Cover = await Task.Run(() => Bitmap.DecodeToWidth(stream, 400));
            }
        }
    }
}
