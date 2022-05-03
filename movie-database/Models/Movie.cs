using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movie_database.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Metadata Metadata { get; set; }

        public Movie(string name, Metadata metadata)
        {
            Name = name;
            Metadata = metadata;
        }
    }
}
