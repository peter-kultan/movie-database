using Newtonsoft.Json;
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
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("id")]
        public int TmdbId { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("genre_ids")]
        [NotMapped]
        public List<int> GenreIds { get; set; }
        
        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        public MovieMetadata(int tmdbId, string backdropPath,
            string originalLanguage, string originalTitle, string overview, double popularity,
            string posterPath, string releaseDate, string title, double voteAverage, int voteCount)
        {
            TmdbId = tmdbId;
            BackdropPath = backdropPath;
            OriginalLanguage = originalLanguage;
            OriginalTitle = originalTitle;
            Overview = overview;
            Popularity = popularity;
            PosterPath = posterPath;
            ReleaseDate = releaseDate;
            Title = title;
            VoteAverage = voteAverage;
            VoteCount = voteCount;
        }

        public MovieMetadata()
        {

        }
    }
}
