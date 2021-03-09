﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _09.ExplicitInterfaces
{
    class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; set; }

        public string Country { get; set; }

        public int Age { get; set; }

        
        public string GetName()
        {
            return "Mr/Ms/Mrs " + this.Name.ToString();
        }
    }
}
