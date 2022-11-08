using Avalonia.Media.Imaging;
using MovieDatabase.DAL.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.ViewModels
{
    public class TVSeriesItemViewModel : ViewModelBase
    {
        private TVSeriesViewModel _tvViewModel;
        private MainWindowViewModel _parent;
        private TVSeriesMetadata _metadata => _tvViewModel.TVSeries.Metadata;
        private bool _hasMetadata => _metadata != null;
        public Bitmap? Cover => _tvViewModel.Cover;
        public string Name => _hasMetadata ? _metadata.Name : _tvViewModel.Name;
        public string AirDate => _hasMetadata ? "FIRST AIR-DATE: " + _metadata.FirstAirDate : "";
        public string Year => _hasMetadata ? "(" + _metadata.FirstAirDate.Split('-')[0] + ")" : "";
        public string OriginLanguage => _hasMetadata ? "ORIGIN LANGUAGE: " + _metadata.OriginalLanguage : "";
        public string OriginalName => _hasMetadata ? "ORIGIN TITLE: " + _metadata.OriginalName : "";
        public string Overview => _hasMetadata ? "OVERVIEW: " + _metadata.Overview : "";
        public string VoteAverage => _hasMetadata ? "VOTE AVERAGE: " + _metadata.VoteAverage : "";
        public string VoteCount => _hasMetadata ? "VOTE COUNT: " + _metadata.VoteCount : "";
        public string Episodes => _hasMetadata ? "Episodes: " + _tvViewModel.TVSeries.Episodes.Select(e => "S" + e.SeasonNumber + " E" + e.EpisodeNumber + ": " + e.Name).Aggregate((e1, e2) => e1 + "\n" + e2) : "";

        public TVSeriesItemViewModel(MainWindowViewModel parent, TVSeriesViewModel tvSeriesViewModel)
        {
            _tvViewModel = tvSeriesViewModel;
            _parent = parent;
        }

        public void BackCommand() => _parent.UpdateViewCommand.Execute("Back");
    }
}
