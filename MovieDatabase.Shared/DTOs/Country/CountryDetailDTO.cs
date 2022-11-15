using MovieDatabaseShared.DTOs.TVSeriesMetadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseShared.DTOs.Country
{
    public class CountryDetailDTO
    {
        public string Name { get; set; }

        public List<TVSeriesMetadataDetailDTO> TVSeriesMetadata { get; set; }
    }
}
