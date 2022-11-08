using MovieDatabase.DAL.EfCore.Api;
using MovieDatabase.DAL.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MovieDatabase.DAL.EfCore
{
    public static class Utils
    {
        private static Settings _settings;

        public static async Task<List<Genre>> GetGenres(bool movie)
        {
            var part = movie ? "movie" : "tv";
            return (await ApiController.GetGenres($"https://api.themoviedb.org/3/genre/{part}/list", new Dictionary<string, string>() { { "api_key", LoadSettings().ApiKey } })).Genres;
        }

        public static string ParseName(string name)
        {
            name = name.ToLower()
                .Replace('_', ' ')
                .Replace('-', ' ')
                .Replace('.', ' ')
                .Replace('(', ' ')
                .Replace(')', ' ');
            Match r = Regex.Match(name, @"\b\d{4}\b");
            string yearFromName = r.Groups[r.Groups.Count - 1].Value;
            return (!string.IsNullOrEmpty(yearFromName)) ? name.Substring(0, name.IndexOf(yearFromName)) : name.Substring(0, name.LastIndexOf(" "));
        }

        public static void Init()
        {
            CreateCacheDir();
            _ = new MovieDatabaseDbContext();
        }

        private static void CreateCacheDir()
        {
            Directory.CreateDirectory(".cache/Posters/");
            Directory.CreateDirectory(".cache/BackDrops/");
        }

        public static Settings LoadSettings()
        {
            if (_settings == null)
            {
                if (!File.Exists(@"Settings.json"))
                {
                    return new Settings("");
                }
                string json = File.ReadAllText(@"Settings.json");
                _settings =  JsonSerializer.Deserialize<Settings>(json);
            }
            return _settings;
        }
    }
}
