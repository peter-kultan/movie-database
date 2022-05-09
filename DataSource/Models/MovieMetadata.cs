using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Models
{
    public class MovieMetadata
    {
        public int Id { get; set; }
        public string BackdropPath { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public string ReleaseDate { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }

        public MovieMetadata(dynamic anonym)
        {
            BackdropPath = anonym["backdrop_path"];
            MovieGenres = Utils.GetMovieGenres(anonym["genre_ids"].ToObject<List<int>>());
            OriginalLanguage = anonym["original_language"];
            OriginalTitle = anonym["original_title"];
            Overview = anonym["overview"];
            Popularity = anonym["popularity"];
            PosterPath = anonym["poster_path"];
            ReleaseDate = anonym["release_date"];
            VoteAverage = anonym["vote_average"];
            VoteCount = anonym["vote_count"];
        }

        public MovieMetadata(string backdropPath, List<MovieGenre> genres,
            string originalLanguage, string originalTitle, string overview,
            double popularity, string posterPath, string releaseDate, double voteAverage, int voteCount)
        {
            BackdropPath = backdropPath;
            MovieGenres = genres;
            OriginalLanguage = originalLanguage;
            OriginalTitle = originalTitle;
            Overview = overview;
            Popularity = popularity;
            PosterPath = posterPath;
            ReleaseDate = releaseDate;
            VoteAverage = voteAverage;
            VoteCount = voteCount;
        }

        public MovieMetadata()
        {

        }
    }
}
