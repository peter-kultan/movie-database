using Avalonia.Media.Imaging;
using DataSource;
using DataSource.Models;
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
    public class MovieItemViewModel : ViewModelBase
    {
        private MovieViewModel _movieTVViewModel;
        private MainWindowViewModel _parent;
        private MovieMetadata _metadata => _movieTVViewModel.Movie.Metadata;
        private bool _hasMetadata => _metadata != null;
        public Bitmap? Cover => _movieTVViewModel.Cover;
        public string Name => _hasMetadata ? _metadata.Title : _movieTVViewModel.Movie.Name;
        public string Year => _hasMetadata ? '(' + _metadata.ReleaseDate.Split("-").First() + ')' : "";
        public string Release => _hasMetadata ? "RELEASED: " + _metadata.ReleaseDate : "";
        public string Language => _hasMetadata ? "ORIGINAL LANGUAGE: " + _metadata.OriginalLanguage : "";
        public string Overview => _hasMetadata ? "OVEWVIEW: " + _metadata.Overview : "";
        public string VoteAverage => _hasMetadata ? "VOTE AVERAGE: " + (_metadata.VoteAverage * 10).ToString() + "%" : "";
        public string VoteCount => _hasMetadata ? "VOTE COUNT: " + _metadata.VoteCount.ToString() : string.Empty;

        public MovieItemViewModel(MainWindowViewModel parent, MovieViewModel movieTVViewModel)
        {
            _parent = parent;
            _movieTVViewModel = movieTVViewModel;
        }

        public void BackCommand() => _parent.UpdateViewCommand.Execute("Back");
    }
}
