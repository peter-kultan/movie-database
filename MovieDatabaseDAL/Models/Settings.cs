using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieDatabaseDAL.Models
{
    public class Settings
    {
        public string ApiKey { get; set; }

        public Settings(string apiKey)
        {
            ApiKey = apiKey;
        }

        public Settings()
        {

        }


        public void Save()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("ApiKey", ApiKey);
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(@"Settings.json", json);
        }
    }
}
