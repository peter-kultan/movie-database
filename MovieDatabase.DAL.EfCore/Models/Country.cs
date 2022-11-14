using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.DAL.EfCore.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<TVSeriesMetadata> Series { get; set; }
    }
}
