using MovieDatabase.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Shared.DTOs.Repository
{
    public class RepositoryCreateDTO
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public RepositoryType reposituryType { get; set; }
    }
}
