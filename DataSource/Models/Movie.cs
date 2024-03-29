﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MovieMetadata? Metadata { get; set; }

        public Movie(string name, MovieMetadata? metadata)
        {
            Name = name;
            Metadata = metadata; 
        }

        public Movie()
        {

        }
    }
}
