using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Models
{
    public class TVSeriesMetadata
    {
        public int Id { get; set; }
        public int TMDBId { get; set; }
        public string BackdropPath { get; set; }
        public string FirstAirDate { get; set; }
        public List<TVSeriesGenre> TVSeriesGenres { get; set; }
        public string[] OriginCountries { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }

        public TVSeriesMetadata(dynamic anonym)
        {
            TMDBId = anonym["id"];
            BackdropPath = anonym["backdrop_path"];
            FirstAirDate = anonym["first_air_date"];
            TVSeriesGenres = Utils.GetTvSeriesGenres(anonym["genre_ids"].ToObject<List<int>>());
            OriginCountries = anonym["origin_country"].ToObject<string[]>();
            OriginalLanguage = anonym["original_language"];
            OriginalTitle = anonym["original_name"];
            Overview = anonym["overview"];
            Popularity = anonym["popularity"];
            PosterPath = anonym["poster_path"];
            VoteAverage = anonym["vote_average"];
            VoteCount = anonym["vote_count"];
        }

        public TVSeriesMetadata(int tmdbId, string backdropPath, string firstAirDate,
            List<TVSeriesGenre> genres, string[] originCountries, string originalLanguage,
            string originalTitle, string overview, double popularity, string posterPath, double voteAverage,
            int voteCount)
        {
            TMDBId = tmdbId;
            BackdropPath = backdropPath;
            FirstAirDate = firstAirDate;
            TVSeriesGenres = genres;
            OriginCountries = originCountries;
            OriginalLanguage = originalLanguage;
            OriginalTitle = originalTitle;
            Overview = overview;
            Popularity = popularity;
            PosterPath = posterPath;
            VoteAverage = voteAverage;
            VoteCount = voteCount;
        }

        public TVSeriesMetadata()
        {
        }
    }
}
