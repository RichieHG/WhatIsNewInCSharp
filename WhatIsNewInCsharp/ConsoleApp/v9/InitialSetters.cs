using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.v9
{
    public class Employee
    {
        public int SSN { get; init; }

        private readonly string LastName;
        public string FirstName;

        public string lastName
        {
            get => LastName;
            init => LastName = value ??
                throw new ArgumentNullException(nameof(lastName));
        }
        public Employee(){ }
        public Employee(int ssn)
        {
            SSN = ssn;
            this[0] = "ABC";
        }

        public string this[int i]
        {
            get { return i>0? LastName : FirstName; }
            init
            {
                if (i > 0) LastName = value;
                else FirstName = value;
            }
        }
    }
}
