using MovieDatabase.Shared.DTOs.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.BL.Services.Interfaces
{
    public interface ISettingsService
    {
        public SettingsDTO? LoadSettings(string path);

        public void SaveSettings(SettingsDTO settings);
    }
}
