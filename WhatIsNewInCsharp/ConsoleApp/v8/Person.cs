using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.v8
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }

        public PhoneNumber? PhoneNumber { get; set; }

        //public Person(string firstName, string lastName, string middleName)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    MiddleName = middleName;
        //}

        public Person(string first, string last, string? middle, PhoneNumber? phone) => (FirstName, LastName, MiddleName, PhoneNumber) = (first, last, middle, phone);

        public string FullName => $"{FirstName} {MiddleName?[0]} {LastName}";
    }
}
