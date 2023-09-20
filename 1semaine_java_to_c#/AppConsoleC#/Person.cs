using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppConsoleC_
{
    [Serializable] public class Person
    {

        private string _name;
        private string _firstname;
        private readonly DateTime _birthDate;

        public virtual string Name {
            get { return _name; }
            set { _name = value; }
        }

        public virtual string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }

        }

        public string BirthDate 
        {
            get { return _birthDate.ToString(); }
        }

        public Person(string name, string firstname, DateTime birthDate)
        {
            this._name = name;
            this._firstname = firstname;
            this._birthDate = birthDate;
        }

        public override string ToString()
        {
            return "Person [name = " + _name + ", firstname = " + _firstname + ", birthDate =  " + BirthDate + "]";
        }


    }

}
