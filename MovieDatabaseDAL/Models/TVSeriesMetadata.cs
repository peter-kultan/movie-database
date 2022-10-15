using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseDAL.Models
{
    public class TVSeriesMetadata
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("id")]
        public int Tmdb { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("first_air_date")]
        public string FirstAirDate { get; set; }

        [JsonProperty("origin_country")]
        [NotMapped]
        public List<string> OriginCountries { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        public TVSeriesMetadata(int tmdb, string backdropPath, string firstAirDate,
            List<string> originCountries, string originalLanguage, string originalName,
            string overview, double popularity, string posterPath, double voteAverage, int voteCount)
        {
            Tmdb = tmdb;
            BackdropPath = backdropPath;
            FirstAirDate = firstAirDate;
            OriginCountries = originCountries;
            OriginalLanguage = originalLanguage;
            OriginalName = originalName;
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
