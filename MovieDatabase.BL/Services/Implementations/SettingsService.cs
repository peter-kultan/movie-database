using AutoMapper;
using MovieDatabase.BL.Services.Interfaces;
using MovieDatabase.DAL.EfCore.Models;
using MovieDatabase.Shared.DTOs.Settings;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.BL.Services.Implementations
{
    public class SettingsService : ISettingsService
    {
        private readonly IMapper _mapper;

        public SettingsService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public SettingsDTO? LoadSettings(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            string json = File.ReadAllText(path);
            var settings = _mapper.Map<SettingsDTO>(JsonSerializer.Deserialize<Settings>(json));
            settings.SettingsPath = path;
            return settings;
        }

        public void SaveSettings(SettingsDTO settings)
        {
            var settingsData = _mapper.Map<Settings>(settings);

            var data = settingsData.GetType().GetProperties().ToDictionary
                (
                    propInfo => propInfo.Name,
                    propInfo => propInfo.GetValue(settingsData, null)?.ToString()
                );

            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(settings.SettingsPath, json);
        }
    }
}
