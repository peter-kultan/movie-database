﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.DAL.EfCore.Models
{
    public class TVSeries
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TVSeriesEpisode> Episodes { get; set; }
        public int MetadataId { get; set; }
        public TVSeriesMetadata Metadata { get; set; }
        public List<Genre> Genres { get; set; }

        public TVSeries(string name, List<TVSeriesEpisode> episodes, TVSeriesMetadata metadata)
        {
            Name = name;
            Episodes = episodes;
            Metadata = metadata;
        }

        public TVSeries(string name, TVSeriesMetadata metadata) : this(name, new(), metadata)
        { }

        public TVSeries()
        {
        }
    }
}
