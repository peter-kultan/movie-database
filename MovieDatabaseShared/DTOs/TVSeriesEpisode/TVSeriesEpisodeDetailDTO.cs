using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseShared.DTOs.TVSeriesEpisode
{
    public class TVSeriesEpisodeDetailDTO
    {
        public string AirDate { get; set; }

        public int EpisodeNumber { get; set; }

        public string Name { get; set; }

        public string Overview { get; set; }

        public int Runtime { get; set; }

        public int SeasonNumber { get; set; }

        public string StillPath { get; set; }

        public double VoteAverage { get; set; }

        public int VoteCount { get; set; }
    }
}
