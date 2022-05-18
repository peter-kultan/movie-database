using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Models
{
    public class TVSeries
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TVSeriesMetadata TVSeriesMetadata { get; set; }
        
        public TVSeries(string name, dynamic anonym)
        {
            Name = name;
            TVSeriesMetadata = new TVSeriesMetadata(anonym);
        }

        public TVSeries(string name, TVSeriesMetadata metadata)
        {
            Name = name;
            TVSeriesMetadata = metadata;
        }

        public TVSeries()
        {
        }
    }
}
