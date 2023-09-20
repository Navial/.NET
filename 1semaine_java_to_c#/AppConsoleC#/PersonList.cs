using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsoleC_
{
    public class PersonList
    {
        private static PersonList _instance;
        private Dictionary<string, Person> _personMap;

        public virtual PersonList Instance 
        {
            get { return _instance; }
        }

        public PersonList()
        {
            _personMap = new Dictionary<string, Person>();
        }

        public IEnumerator<Person> AddPerson(Person person)
        {
            return _personMap.Values.GetEnumerator();
        }
    }
}
