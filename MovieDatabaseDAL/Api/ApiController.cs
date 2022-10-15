using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using MovieDatabaseDAL.Models;

namespace MovieDatabaseDAL.Api
{
    public static class ApiController
    {

        public static async Task<TVSeriesEpisode> GetTVSeriesEpisode(string address, Dictionary<string, string> queryParameters)
        {
            using var client = new HttpClient();
            address = BuildAddress(address, queryParameters);

            var serializer = new JsonSerializer();
            return serializer.Deserialize<TVSeriesEpisode>(new JsonTextReader(new StreamReader((await client.GetAsync(address)).Content.ReadAsStream())));
        }
        public static async Task<MovieResponse?> GetMovies(string address, Dictionary<string, string> queryParameters)
        {
            using var client = new HttpClient();
            address = BuildAddress(address, queryParameters);
            
            var serializer = new JsonSerializer();
            return serializer.Deserialize<MovieResponse>(new JsonTextReader(new StreamReader((await client.GetAsync(address)).Content.ReadAsStream())));
        }

        public static async Task<TVSeriesResponse?> GetTVSeries(string address, Dictionary<string, string> queryParameters)
        {
            using var client = new HttpClient();
            address = BuildAddress(address, queryParameters);

            var serializer = new JsonSerializer();
            return serializer.Deserialize<TVSeriesResponse>(new JsonTextReader(new StreamReader((await client.GetAsync(address)).Content.ReadAsStream())));
        }

        public static async Task<GenreResponse?> GetGenres(string address, Dictionary<string, string> queryParameters)
        {
            using var client = new HttpClient();
            address = BuildAddress(address, queryParameters);

            var serializer = new JsonSerializer();
            return serializer.Deserialize<GenreResponse>(new JsonTextReader(new StreamReader((await client.GetAsync(address)).Content.ReadAsStream())));
        }

        private static string BuildAddress(string address, Dictionary<string, string> queryParameters)
        {
            address += "?";
            foreach (var parameter in queryParameters)
            {
                address += $"{parameter.Key}={parameter.Value}&";
            }

            return address;
        }
    }
}
