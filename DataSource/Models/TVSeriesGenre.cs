using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Models
{
    public class TVSeriesGenre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TVSeriesGenre(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public TVSeriesGenre()
        {
        }
    }
}
