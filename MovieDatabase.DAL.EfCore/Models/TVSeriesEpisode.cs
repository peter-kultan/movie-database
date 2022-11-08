using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.DAL.EfCore.Models
{
    public class TVSeriesEpisode
    {
        [JsonIgnore]
        [Key]
        public int Id { get; set; }

        [JsonProperty("air_date")]
        public string AirDate { get; set; }

        [JsonProperty("episode_number")]
        public int EpisodeNumber { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("id")]
        public int TmdbId { get; set; }

        [JsonProperty("runtime")]
        public int Runtime { get; set; }

        [JsonProperty("season_number")]
        public int SeasonNumber { get; set; }

        [JsonProperty("still_path")]
        public string StillPath { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }
        public TVSeries TvSeries { get; set; }

        public TVSeriesEpisode(string airDate, int episodeNumber, string name, string overview,
            int tmdbId, int runtime, int seasonNumber, string stillPath, double voteAverage, int voteCount)
        {
            AirDate = airDate;
            EpisodeNumber = episodeNumber;
            Name = name;
            Overview = overview;
            TmdbId = tmdbId;
            Runtime = runtime;
            SeasonNumber = seasonNumber;
            StillPath = stillPath;
            VoteAverage = voteAverage;
            VoteCount = voteCount;
        }

        public TVSeriesEpisode()
        {
        }
    }
}
