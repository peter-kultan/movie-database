using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Shared.DTOs.Movie
{
    public class MovieAlbumViewDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PosterPath { get; set; }
    }
}
