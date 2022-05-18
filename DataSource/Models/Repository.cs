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
        private string _path;
        public string Path
        { 
            get
            {
                return _path;
            }
            set
            {
                if ((File.GetAttributes(value) & FileAttributes.Directory) != FileAttributes.Directory)
                {
                    throw new ArgumentException("Bad directory path");   
                }
                _path = value;
            }
        }
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
