using MovieDatabaseShared.DTOs.Genre;
using MovieDatabaseShared.DTOs.TVSeriesEpisode;
using MovieDatabaseShared.DTOs.TVSeriesMetadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseShared.DTOs.TVSeries
{
    public class TVSeriesDetailDTO
    {
        public string Name { get; set; }

        public List<TVSeriesEpisodeDetailDTO> Episodes { get; set; }

        public int MetadataId { get; set; }

        public TVSeriesMetadataDetailDTO Metadata { get; set; }

        public List<GenreDetailDTO> Genres { get; set; }
    }
}
