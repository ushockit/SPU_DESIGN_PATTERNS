using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Prototype
{
    public class Person : IPrototype<Person>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birth { get; set; }

        public Person Clone()
        {
            return new Person
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Birth = Birth
            };
        }
    }
}
