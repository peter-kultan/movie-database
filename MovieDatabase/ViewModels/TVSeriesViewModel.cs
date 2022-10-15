using Avalonia.Media.Imaging;
using MovieDatabaseDAL.Models;
using ReactiveUI;
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
    public class TVSeriesViewModel : ViewModelBase
    {
        private Bitmap? _cover;

        public string Name => TVSeries.Metadata != null ? TVSeries.Metadata.Name : TVSeries.Name;

        public TVSeries TVSeries { get; set; }

        public TVSeriesViewModel(TVSeries tvSeries)
        {
            TVSeries = tvSeries;
        }

        public Bitmap? Cover
        {
            get => _cover;
            private set => this.RaiseAndSetIfChanged(ref _cover, value);
        }

        public async Task LoadCover()
        {
            var imagePath = TVSeries.Metadata != null ? TVSeries.Metadata.PosterPath : "";

            if (imagePath == "")
            {
                return;
            }

            if (!File.Exists($".cache/Posters/{imagePath}"))
            {
                using (HttpClient client = new())
                {
                    File.WriteAllBytes($".cache/Posters{imagePath}", await client.GetByteArrayAsync(new Uri($"https://image.tmdb.org/t/p/original{imagePath}")));
                }
            }

            await using (var stream = File.OpenRead($".cache/Posters{imagePath}"))
            {
                Cover = await Task.Run(() => Bitmap.DecodeToWidth(stream, 400));
            }
        }

            public override string ToString()
        {
            return "TVSeriesView";
        }
    }
}
