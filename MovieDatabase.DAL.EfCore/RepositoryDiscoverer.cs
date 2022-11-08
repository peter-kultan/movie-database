using MovieDatabase.DAL.EfCore.Api;
using MovieDatabase.DAL.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseDAL

{
    public static class RepositoryDiscoverer
    {
        public static IEnumerable<string> GetVideoFiles(string path)
        {
            var extensions = new string[] { "*.mp4", "*.avi", "*.mkv", "*.mov", "*.mkv" };
            return extensions.SelectMany(extension => Directory.GetFiles(path, extension));
        }

       public static async Task<List<Movie>> DiscoverFilmRepository(string path)
        {
            var movies = new List<Movie>();
            
            foreach (var file in GetVideoFiles(path))
            {
                var fileName = Path.GetFileName(file);
                var result = await ApiController.GetMovies("https://api.themoviedb.org/3/search/movie", new Dictionary<string, string>() { { "api_key", Utils.LoadSettings().ApiKey }, { "query", Utils.ParseName(fileName) } });
                if (result.TotalResults == 0)
                {
                    movies.Add(new(fileName, null));
                }
                else
                {
                    var movie = new Movie(fileName, result.Results[0]);
                    movies.Add(movie);
                }
            }
            foreach (var m in Directory.GetDirectories(path).Select(x => DiscoverFilmRepository(x)))
            {
                movies.AddRange(await m);
            }
            return movies;
        }

        public static async Task<List<TVSeries>> DiscoverTVRepository(string path)
        {
            var series = new List<TVSeries>();
            foreach (var tv in Directory.GetDirectories(path))
            {
                var dirName = Utils.ParseName($"{Path.GetFileName(tv)}.mp4");
                var res = await ApiController.GetTVSeries("https://api.themoviedb.org/3/search/tv", new Dictionary<string, string>() { { "api_key", Utils.LoadSettings().ApiKey }, { "query", dirName  } });
                if (res.Results.Count == 0)
                {
                    series.Add(new());
                }
                else
                {
                    var ser = new TVSeries(tv, res.Results[0]);
                    ser.Episodes = await DiscoverEpisodes(tv, ser.Metadata.Tmdb);
                    series.Add(ser);
                }
            } 
            return series;
        }


        private static async Task<List<TVSeriesEpisode>> DiscoverEpisodes(string path, int tmdbId)
        {
            List<TVSeriesEpisode> episodes = new();
            var firstTuples = GetVideoFiles(path).Select(d => Path.GetFileNameWithoutExtension(d).Split('s', 'e')).Select(d => Tuple.Create(d[1], d[2]));

            var dirs = Directory.GetDirectories(path);
            var tuples = dirs.Select(GetVideoFiles).SelectMany(x => x).Select(x => Tuple.Create(Path.GetFileName(Path.GetDirectoryName(x)).Split('s')[1], Path.GetFileNameWithoutExtension(x).Split('e')[1])).ToList();
            tuples.AddRange(firstTuples);
            foreach(var tup in tuples)
            {
                var episode = await ApiController.GetTVSeriesEpisode($"https://api.themoviedb.org/3/tv/{tmdbId}/season/{tup.Item1}/episode/{tup.Item2}", new() { { "api_key", Utils.LoadSettings().ApiKey } });
                if (episode.TmdbId != 0)
                {
                    episodes.Add(episode);
                }
            }
            return episodes;
        }
    }
}
