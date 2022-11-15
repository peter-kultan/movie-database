using MovieDatabaseShared.DTOs.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseShared.DTOs.Genre
{
    public class GenreDetailDTO
    {
        public string Name { get; set; }

        public List<MovieDetailDTO> Movies { get; set; }

        //public List<TVSeries> TVSeries { get; set; }
    }
}
