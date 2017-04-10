using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalPeopleDBEli
{
    class Person
    {
        public Person(int id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;

        }

        public int Id;
        public string Name;
        public int Age;

        public override string ToString()
        {
            return String.Format("{0}: {1} is {2} y/o", Id, Name, Age);
        }
    }

}
