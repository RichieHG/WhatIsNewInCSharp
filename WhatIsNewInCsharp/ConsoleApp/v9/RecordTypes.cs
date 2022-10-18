using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.v9
{
    public record Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
    }
    
    public record Address
    {
        public int HouseNumber { get; set; }
        public string Street { get; set; }

        public Address()
        {
        }

        public Address(int houseNumber, string street)
        {
            HouseNumber = houseNumber;
            Street = street;
        }
    }

    public record Point(int X, int Y);

    public record Car
    {
        public Color Color { get; set; }
        public string Engine { get; set; }
    }

   public record Color
    {
        public string Name { get; set; }
        public bool Metallic { get; set; }

        public Color()
        {
        }

        public Color(string name, bool metallic)
        {
            Name = name;
            Metallic = metallic;
        }
    }
}
