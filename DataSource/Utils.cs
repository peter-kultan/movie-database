using DataSource.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataSource
{
    public static class Utils
    {

        private static Dictionary<int, TVSeriesGenre> TVSeriesGenres = null;
        private static Dictionary<int, MovieGenre> MovieGenres = null;

        public static List<TVSeriesGenre> GetTvSeriesGenres(List<int> ids)
        {
            if (TVSeriesGenres == null)
            {
                var response = Api.ApiController.GetList("https://api.themoviedb.org/3/genre/tv/list", new Dictionary<string, string>() { { "api_key", "a3baf7a02cdd3e1aa7b800d05ea630ea" } });
                TVSeriesGenres = response.ToTVSeriesGenres().ToDictionary(x => x.Id, x => x);
            }
            return ids.Join(TVSeriesGenres,
                id => id,
                genre => genre.Key,
                (id, genre) => genre.Value).ToList();
        }

        public static List<MovieGenre> GetMovieGenres(List<int> ids)
        {
            if (MovieGenres == null)
            {
                var response = Api.ApiController.GetList("https://api.themoviedb.org/3/genre/movie/list", new Dictionary<string, string>() { { "api_key", "a3baf7a02cdd3e1aa7b800d05ea630ea" } });
                MovieGenres = response.ToMovieGenres().ToDictionary(x => x.Id, x => x);
            }
            return ids.Join(MovieGenres,
                id => id,
                genre => genre.Key,
                (id, genre) => genre.Value).ToList();
        }

        public static string ParseName(string name)
        {
            name = name.ToLower()
                .Replace('_', ' ')
                .Replace('.', ' ')
                .Replace('(', ' ')
                .Replace(')', ' ');
            Match r = Regex.Match(name, "\b\b{4}\b");
            string yearFromName = r.Groups[r.Groups.Count - 1].Value;
            return (!string.IsNullOrEmpty(yearFromName)) ? name.Substring(0, name.IndexOf(yearFromName)) : name;
        }

        public static void Init()
        {
            CreateCacheDir();
        }

        private static void CreateCacheDir()
        {
            Directory.CreateDirectory(".cache/Posters/");
            Directory.CreateDirectory(".cache/BackDrops/");
        }
    }
}
