using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Api
{
    public class Response
    {
        public int Page { get; set; }
        public List<dynamic> Results { get; set; } = new();
        public List<dynamic> genres { get; set; } = new();
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }
}
