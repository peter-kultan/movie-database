using MovieDatabase.DAL.EfCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.DAL.EfCore.Api
{
    public class MovieResponse
    {
        public int Page { get; set; }

        public List<MovieMetadata> Results { get; set; } = new();

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

    }
}
