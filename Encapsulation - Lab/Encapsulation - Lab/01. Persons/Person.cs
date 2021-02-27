using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        public Person(string first, string second, int personAge)
        {
            this.FirstName = first;
            this.LastName = second;
            this.Age = personAge;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }


        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        }



    }
}
