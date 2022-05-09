using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Models
{
    public class MovieGenre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public MovieGenre(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public MovieGenre()
        {
        }
    }
}
