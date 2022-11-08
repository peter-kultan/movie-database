using MovieDatabase.DAL.EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.DAL.EfCore.Api
{
    public class GenreResponse
    {
        public List<Genre> Genres { get; set; }
    }
}
