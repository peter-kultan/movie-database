using DataSource.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource
{
    public static class RepositoryDiscoverer
    {
       public static List<Movie> DiscoverFilmRepository(string path)
        {
            var movies = new List<Movie>();
            foreach (var file in Directory.GetFiles(path))
            {
                var fileName = Path.GetFileName(file);
                var result = Api.ApiController.Get("https://api.themoviedb.org/3/search/movie", new Dictionary<string, string>() { { "api_key", Utils.LoadSettings().ApiKey }, { "query", Utils.ParseName(fileName) } });
                if (result.Results.Count == 0)
                {
                    movies.Add(new(fileName, null));
                }
                else
                {
                    movies.Add(new(fileName, result.Results[0]));
                }
            }
            foreach (var m in Directory.GetDirectories(path).Select(x => DiscoverFilmRepository(x)))
            {
                movies.AddRange(m);
            }
            return movies;
        }

        public static List<TVSeries> DiscoverTVRepository(string path)
        {
            var series = new List<TVSeries>();
            foreach (var tv in Directory.GetDirectories(path))
            {
                var dirName = Utils.ParseName($"{Path.GetFileName(tv)}.mp4");
                var res = Api.ApiController.Get("https://api.themoviedb.org/3/search/tv", new Dictionary<string, string>() { { "api_key", Utils.LoadSettings().ApiKey }, { "query", dirName  } });
                if (res.Results.Count == 0)
                {
                    series.Add(new(dirName, null));
                }
                else
                {
                    series.Add(new(dirName, res.Results[0]));
                }
            } 
            return series;
        }
    }
}
