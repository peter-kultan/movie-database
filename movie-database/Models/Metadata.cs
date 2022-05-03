using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movie_database.Models
{
    public class Metadata
    {
        public int Id { get; set; }

        public DateOnly ReleaseDate { get; set; }

        public string PosterHtml { get; set; }

        public Metadata(DateOnly date, string Poster)
        {
            ReleaseDate = date;
            PosterHtml = Poster;
        }
    }
}
