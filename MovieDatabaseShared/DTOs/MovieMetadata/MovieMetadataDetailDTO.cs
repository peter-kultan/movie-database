using MovieDatabaseShared.DTOs.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseShared.DTOs.MovieMetadata
{
    public class MovieMetadataDetailDTO
    {
        public string BackDropPath { get; set; }

        public List<GenreDetailDTO> Genres { get; set; }

        public string OriginalLanguage { get;set; }

        public string OriginalTitle { get; set; }

        public string Overview { get; set; }

        public double Popularity { get; set; }

        public string PosterPath { get; set; }

        public string Title { get; set; }

        public double VoteAverage { get; set; }

        public int VoteCount { get; set; }
    }
}
