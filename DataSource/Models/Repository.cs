using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Models
{
    public class Repository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public RepositoryType RepositoryType { get; set; }

        public Repository(string name, string path, RepositoryType repositoryType)
        {
            Name = name;
            Path = path;
            RepositoryType = repositoryType;
        }

        public Repository()
        {
        }
    }
}
