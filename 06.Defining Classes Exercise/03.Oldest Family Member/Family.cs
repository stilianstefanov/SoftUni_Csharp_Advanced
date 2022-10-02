using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            this.People = new List<Person>();
        }

        private List<Person> people;

        public List<Person> People
        {
            get { return people; }
            set { people = value; }
        }
        

        public void AddMember(Person person)
        {
            this.People.Add(person);
        }
        public Person GetOldestMember()
        {
            return this.People.OrderByDescending(p => p.Age).First();
        }
    }
}
