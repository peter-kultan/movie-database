using DataSource.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Api
{
    public class ListResponse
    {
        public List<dynamic> Genres { get; set; }

        public List<MovieGenre> ToMovieGenres()
        {
            return Genres.Select(x => new MovieGenre(x["id"].ToObject<int>(), x["name"].ToObject<string>())).ToList();
        }

        public List<TVSeriesGenre> ToTVSeriesGenres()
        {
            return Genres.Select(x => new TVSeriesGenre(x["id"].ToObject<int>(), x["name"].ToObject<string>())).ToList();
        }
    }
}
