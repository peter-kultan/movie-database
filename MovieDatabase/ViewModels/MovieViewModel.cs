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
    public class MovieViewModel : ViewModelBase
    {
        private Bitmap? _cover;



        public string Name => Movie.Metadata != null ? Movie.Metadata.Title : Movie.Name;
        public Movie Movie { get; set; }

        public MovieViewModel(Movie movie)
        {
            Movie = movie;
        }

        public Bitmap? Cover
        {
            get => _cover;
            private set => this.RaiseAndSetIfChanged(ref _cover, value);
        }

        public async Task LoadCover()
        {
            var imagePath = Movie.Metadata != null ? Movie.Metadata.PosterPath : "";

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

            await using(var stream = File.OpenRead($".cache/Posters{imagePath}"))
            {
                Cover = await Task.Run(() => Bitmap.DecodeToWidth(stream, 400));
            }
        }

        public override string ToString()
        {
            return "MovieView";
        }
    }
}
