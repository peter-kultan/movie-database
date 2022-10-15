using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseDAL.Models
{
    public class Genre
    {
        [JsonProperty("id")]
        [Key]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public List<Movie> Movies { get; set; }
        public List<TVSeries> TVSeries { get; set; }

        public Genre(string name, List<Movie> movies, List<TVSeries> tVSeries)
        {
            Name = name;
            Movies = movies;
            TVSeries = tVSeries;
        }

        public Genre(string name) : this(name, new(), new())
        { }

        public Genre()
        {
        }
    }
}
