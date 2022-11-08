using MovieDatabaseDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseDAL.Api
{
    public class GenreResponse
    {
        public List<Genre> Genres { get; set; }
    }
}
