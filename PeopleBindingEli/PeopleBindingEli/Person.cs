using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleBindingEli
{
    class Person
    {
        static int idCount = 1;
        private int ID;
        private string Name;
        private int Age;
        public Person()
        {
        }
        public Person(string name, int age)
        {
           
            this.Name1 = name;
            this.Age1 = age;
            this.ID1 = idCount++;

        }



        public int ID1
        {
            get { return ID; }
            set
            {
                ID = value;

            }
        }

        public string Name1
        {
            get { return Name; }
            set
            {

                if (value.Length < 2 || value.Length > 50 || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name must be 2 to 50 character");
                }
                Name = value;

            }
        }
        public int Age1
        {
            get { return Age; }
            set
            {

                if (value < 1 || value > 150)
                {
                    throw new ArgumentException("Age must be between 1 to 150");
                }
                Age = value;

            }
        }

        public override string ToString()
        {

            return string.Format("{0} -- {1} -- {2}", Name1, Age1);
        }



    }
}
