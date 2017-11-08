using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITR
{
    public class Person
    {
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Person(string _name, int _age)
        {
            this.name = _name;
            this.age = _age;
        }

    }
}