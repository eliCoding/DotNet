using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibDB
{
    class Genre
    {
        int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        } 

        public Genre(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
