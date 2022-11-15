using MovieDatabaseShared.DTOs.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseShared.DTOs.TVSeriesMetadata
{
    public class TVSeriesMetadataDetailDTO
    {
        public string Name { get; set; }

        public string BackDropPath { get; set; }

        public string FirstAirDate { get; set; }

        public List<CountryDetailDTO> OriginCountries { get; set; }

        public string OriginalLanguage { get; set; }

        public string OriginalName { get; set; }

        public string Overview { get; set; }

        public double Popularity { get; set; }

        public string PosterPath { get; set; }

        public double VoteAverage { get; set; }

        public int VoteCount { get; set; }
    }
}
