using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace DataSource.Api
{
    public static class ApiController
    {
        public static Response? Get(string address, Dictionary<string, string> queryParameters)
        {
            using var client = new HttpClient();
            address = BuildAddress(address, queryParameters);
            return Deserializer(Task.Run(() => client.GetAsync(address)));
        }


        public static ListResponse? GetList(string address, Dictionary<string, string> queryParameters)
        {
            using var client = new HttpClient();
            address = BuildAddress(address, queryParameters);
            return ListDeserializer(Task.Run(() => client.GetAsync(address)));
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

        public static ListResponse? ListDeserializer(Task<HttpResponseMessage> content)
        {
            while (content.Status != TaskStatus.RanToCompletion)
            { }

            var serializer = new JsonSerializer();
            return serializer.Deserialize<ListResponse>(new JsonTextReader(new StreamReader(content.Result.Content.ReadAsStream())));
        }

        public static Response? Deserializer(Task<HttpResponseMessage> content)
        {
            while (content.Status != TaskStatus.RanToCompletion)
            { }

            var serializer = new JsonSerializer();
            return serializer.Deserialize<Response>(new JsonTextReader(new StreamReader(content.Result.Content.ReadAsStream())));
        }
    }
}
